using System;
using System.Data;
using System.Drawing;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;
using System.Linq;
using Cyotek.Windows.Forms;

using PCComm;

namespace MultiControlHost
{
    public delegate void blinkFrameCallBack(bool blink);

    public partial class MainWindow : Form
    {
        public ComConnectionController comController = new ComConnectionController("MultiControlHost.exe.config");
        public ComConnectionController.ConfigDefaults configDefaults = new ComConnectionController.ConfigDefaults();
        public RGBcolorPreset LightEffect;

        private ToolStripLabel currentFrameStatusLED = null;
        private bool RGBLightPowered = false;

        /*
         * Запуск приложения
         */
        public MainWindow()
        {
            InitializeComponent();
            
            comController.LoadConfig();
            comController.Connect(true);
          
            comController.Connection.NewSerialDataRecieved += new EventHandler<SerialDataEventArgs>(SerialFrameReceived);
            comController.SensorValueArrived += new ComConnectionController.TempValueArrivedHandler(processWidgetTemperature);
           
            CallBackMy.addRemoteWindowClosingHandler = new CallBackMy.addRemoteWindowClosing(this.wnd_AddRemote_Closing);
            CallBackMy.callbackEventHandler = new CallBackMy.callbackEvent(this.connectionRestart);
            CallBackMy.serialDataTransmittingHandler = new CallBackMy.serialDataTransmitting(this.blinkTX);

            if (comController.Connection.IsConnected())
            {
                comController.SendFrame(FrameMarker.TEMPERATURE_ENUM);
            }
        }

        /*
         * Завершение приложения
         */
        private void OnApplicationExit(object sender, EventArgs e)
        {
            if (comController.dbConnection.isOpened())
            {
                comController.dbConnection.Close();
            }

            if (comController.Connection.IsConnected())
            {
                this.RGBPower(false);
                comController.Connection.Dispose();
            }
        }

        /*
         * Открытие главной формы приложения
         */
        private void Form1_Load(object sender, EventArgs e)
        {
            this.loadConfigDefaults();

            // Заполнение списка ИК пультов и установка текущего выбранного
            this.populateIRControllerList(sel_CurrentInfraredController);
            if (this.configDefaults.IRCcontroller != null)
            {
                status_CurrentRC.Text = this.configDefaults.IRCcontroller;
            }
            else
            {
                status_CurrentRC.Text = "не выбран";
            }
            
            // Установка текущего режима подстветки
            this.populateRGBModesList();
            if (this.configDefaults.RGBmode == "singleColor")
            {
                sel_RGBMode.SelectedIndex = 0;
            }
            else if (this.configDefaults.RGBmode == "colorPreset")
            {
                sel_RGBMode.SelectedIndex = 1;
            }
        }

        /*
         * Закрытие главной формы приложения
         */
        private void MainWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.RGBPower(false);
        }

        /*
         * Загрузка из конфига параметров по-умолчанию
         */
        private void loadConfigDefaults()
        {
            configDefaults.RGBmode = comController.RGBConfig.Options.mode.value;
            configDefaults.RGBColor = comController.RGBConfig.Options.defaultColor.value;
            configDefaults.IRCcontroller = comController.InfraredConfig.Options.CurrentRemoteController.value;
        }

        /*
         * Обрабатываем входящие UART кадры
         */
        public void SerialFrameReceived(object sender, SerialDataEventArgs e)
        {
            try
            {
                if (this.InvokeRequired)
                {
                    // Using this.Invoke causes deadlock when closing serial port, and BeginInvoke is good practice anyway.
                    this.BeginInvoke(new EventHandler<SerialDataEventArgs>(SerialFrameReceived), new object[] { sender, e });
                    return;
                }

                blinkRX();

                if (comController.Connection.ReceiveMode == CommunicationManager.ReceiveModes.Idle)
                {
                    //Console.WriteLine(comController.ByteToHex(e.Frame.RawData));

                    if (e.Frame.Recognized)
                    {
                        comController.RX_Frames++;
                        switch (e.Frame.Type)
                        {
                            case FrameMarker.RESET:
                                    toggleErrorLed(false);
                                    comController.SendFrame(FrameMarker.TEMPERATURE_ENUM);
                                    comController.sensorTimersControl(true);
                                    break;
                            case FrameMarker.ERROR:
                                {
                                    comController.ERR_Frames++;
                                    toggleErrorLed(true, e.Frame.Error.ToString());
                                    comController.sensorTimersControl(false);
                                    break;
                                }
                            case FrameMarker.INFRARED:
                                {
                                    comController.IRC_Frames++;
                                    Console.WriteLine(comController.ByteToHex(e.Frame.RawData));
                                    currentFrameStatusLED = status_IRC;
                                    break;
                                }
                            case FrameMarker.TEMPERATURE_ENUM:
                                {
                                    comController.TEM_Frames++;
                                    currentFrameStatusLED = status_TEM;
                                    comController.EnumTempSensors(e.Frame);
                                    this.populateTempSensorTable(table_TempSensors);
                                    this.populateSensorsList();
                                    break;
                                }
                            case FrameMarker.TEMPERATURE_SENSOR:
                                {
                                    comController.TEM_Frames++;
                                    currentFrameStatusLED = status_TEM;
                                    if (e.Frame.DataSize > 0)
                                    {
                                        IDictionary<string, float> sensorTemperature = comController.GetTemperature(e.Frame);
                                        if (sensorTemperature != null)
                                        {
                                            string sensorROM = sensorTemperature.Keys.ToList()[0];
                                            float tempValue = sensorTemperature.Values.ToList()[0];

                                            this.updateTemperatureValues(sensorROM, tempValue);
                                            if (comController.OWbusSensors.Keys.Contains(sensorROM))
                                            {
                                                ComConnectionController.SensorStatus cSensorStatus = comController.OWbusSensors[sensorROM];
                                                cSensorStatus.Value = tempValue;
                                                comController.OWbusSensors[sensorROM] = cSensorStatus;
                                            }
                                        }
                                    }
                                    break;
                                }
                            case FrameMarker.RGB_COLOR:
                            case FrameMarker.RGB_MODE:
                            case FrameMarker.RESISTIVE:
                                {
                                    break;
                                }

                        }
                        if (comController.OWbusSensors.Count > 0 && comController.sensorTimersRunning == false && e.Frame.Type != FrameMarker.ERROR)
                        {
                            comController.InitSensorTimers();
                        }
                        if (currentFrameStatusLED != null)
                        {
                            blinkFrameStatus();
                        }
                    }
                    e.Frame = null;
                }
            }
            catch (Exception ex)
            {
               MessageBox.Show("Исключение: " + ex.Message + "\nОбъект: " + ex.TargetSite.ToString() + "\nДополнительно: " + ex.ToString(), "Исключение в главном модуле");
            }

            status_RX.ToolTipText = comController.RX_Frames.ToString() + " пакетов получено";
            status_TX.ToolTipText = comController.TX_Frames.ToString() + " пакетов отправлено";
            status_IRC.ToolTipText = comController.IRC_Frames.ToString() + " пакетов получено";
            status_RES.ToolTipText = comController.RES_Frames.ToString() + " пакетов получено";
            status_TEM.ToolTipText = comController.TEM_Frames.ToString() + " пакетов получено";
            status_RGB.ToolTipText = comController.RGB_Frames.ToString() + " пакетов получено";

        }

        /*
         * Действия по кликам на вкладках главного окна
         */
        private void tab_Peripherals_Selected(object sender, TabControlEventArgs e)
        {
            /*
             *  Вкладка ИК-приемника
             */
            if (e.TabPage == tab_INFRARED)
            {
                populateIRControllerList(sel_CurrentInfraredController);
            }

            /*
             *  Вкладка датчиков темепературы
             */
            else if (e.TabPage == tab_TEMPERATURE)
            {
                comController.SendFrame(FrameMarker.TEMPERATURE_ENUM);
                populateTempSensorTable(table_TempSensors);
            }

            /*
             * Главная вкладка
             */
            else if (e.TabPage == tab_MAIN)
            {
                this.populateSensorsList();
            }
        }


        #region Таймеры индикаторов статусной строки
        /*
         * Таймер мерцания индикатора приёма
         */
        private void timer_Blink_Tick(object sender, EventArgs e)
        {
            status_RX.BackColor = Color.Gainsboro;
            timer_Blink_RX.Enabled = false;
        }

        /*
         * Таймер мерцания индикатора передачи
         */
        private void timer_Blink_TX_Tick(object sender, EventArgs e)
        {
            status_TX.BackColor = Color.Gainsboro;
            timer_Blink_TX.Enabled = false;
        }

        /*
         * Таймер мерцания индикатора типа кадра
         */
        private void timer_Blink_Frame_Tick(object sender, EventArgs e)
        {
            Timer frameTimer = ((Timer)sender);
            frameTimer.Stop();
            currentFrameStatusLED.BackColor = Color.Gainsboro;
            timer_Blink_Frame.Enabled = false;
            frameTimer.Start();
        }

        #endregion

        #region Элементы интерфейса статусной строки

        /*
         * Клик на индикаторе статуса соединения
         * Отображение настроек соединения
         */
        private void status_Connection_Click(object sender, EventArgs e)
        {
            comController.sensorTimersControl(false);
            comController.Connection.Close();
            setConnectionStatus(false);
            timer_ConnectionCheck.Stop();
            ConnectionOptionsWindow connOptionsWindow = new ConnectionOptionsWindow();
            connOptionsWindow.Show();
        }

        /* 
         * Выставить указанный индикатор типа кадра в положение ВКЛ
         * Запустить таймер периода мерцания индикатора
         */
        public void blinkFrameStatus()
        {
            this.currentFrameStatusLED.BackColor = Color.Chartreuse;
            this.timer_Blink_Frame.Enabled = true;
        }

        /* 
         * Выставить индикатор приема в положение ВКЛ
         * Запустить таймер периода мерцания индикатора
         */
        public void blinkRX()
        {
            this.status_RX.BackColor = Color.Chartreuse;
            this.timer_Blink_RX.Enabled = true;
        }

        /* 
         * Выставить индикатор передачи в положение ВКЛ
         * Запустить таймер периода мерцания индикатора
         */
        public void blinkTX()
        {
            this.status_TX.BackColor = Color.Chartreuse;
            this.timer_Blink_TX.Enabled = true;
        }

        /*
         * Зажигает или гасит индикатор ошибки обмена данными в строке состояния.
         * Отображает краткое описание ошибки во всплывающей подсказке на индикаторе
         */
        public void toggleErrorLed(bool isError, string errorMessage = null)
        {
            if (isError)
            {
                status_Error.BackColor = Color.Red;
                status_Error.ForeColor = Color.White;
                if (errorMessage != null)
                {
                    status_Error.ToolTipText = errorMessage;
                }
                else
                {
                    status_Error.ToolTipText = "Неизвестная ошибка";
                }
            }
            else
            {
                status_Error.BackColor = Color.Gainsboro;
                status_Error.ForeColor = Color.Black;
                status_Error.ToolTipText = comController.ERR_Frames.ToString() + " ошибок";
            }
        }

        /*
         * Установка статуса соединения в строке состояния
         */
        public void setConnectionStatus(bool isConnected)
        {
            Color statusRED = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            Color statusGREEN = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));

            if (isConnected)
            {
                status_Connection.BackColor = statusGREEN;
                status_Connection.Text = "Подключён к " + comController.Connection.PortName;
            }
            else
            {
                status_Connection.BackColor = statusRED;
                status_Connection.Text = "Нет подключения";
            }
        }

        #endregion

        #region Управление соединением
        /*
         * Перезапуск соединения.
         * Старт таймера проверки соединения.
         */
        private void connectionRestart() {
            comController.LoadConfig();
            if (!comController.Connection.IsConnected())
            {
                comController.Connect(true);
            }
            comController.InitSensorTimers();
            timer_ConnectionCheck.Enabled = true;
        }

        /*
         * Таймер, по которому проверяется состояние соединения и выставляется соответствующий статус.
         * Если соедниения нет, то делается попытка его установить.
         */
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (comController.Connection.IsConnected())
            {
                setConnectionStatus(true);
            }
            else
            {
                comController.sensorTimersControl(false);
                setConnectionStatus(false);
                try
                {
                    comController.Connect(false);
                }
                catch
                {
                    return;
                }
            }
        }

        #endregion

        #region Методы для вкладки ИК-Приемника
        /*
         * Вызывается, когда закрылось окно добавления или редактирования ИК-пультов
         */
        private void wnd_AddRemote_Closing()
        {
            populateIRControllerList(sel_CurrentInfraredController);
        }

        /*
         * Открываем окно добавления новго ИК-пульта
         */
        private void btn_AddRemote_Click(object sender, EventArgs e)
        {
            comController.sensorTimersControl(false);
            comController.Connection.Close();
            setConnectionStatus(false);
            timer_ConnectionCheck.Stop();

            AddRemote AddRemoteWindow = new AddRemote();
            AddRemoteWindow.Show();
        }

        /*
         * Открываем окно редактирования ИК-пульта
         */
        private void btn_ModifyRemote_Click(object sender, EventArgs e)
        {
            if (sel_CurrentInfraredController.SelectedIndex >= 0)
            {
                comController.sensorTimersControl(false);
                comController.Connection.Close();
                setConnectionStatus(false);
                timer_ConnectionCheck.Stop();
                AddRemote AddRemoteWindow = new AddRemote(sel_CurrentInfraredController.SelectedItem.ToString());
                AddRemoteWindow.Show();
            }
            else
            {
                MessageBox.Show("Выберите пульт для редактирования!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
     
        /*
         *  Удаляем выбранный ИК-пульт из конфигурациии
         */
        private void btn_RemoveRemote_Click(object sender, EventArgs e)
        {
            string victim_name = sel_CurrentInfraredController.SelectedItem.ToString();
            foreach (RemoteController rController in comController.InfraredConfig.RemoteControllers)
            {
                if (rController.name == victim_name)
                {
                    comController.InfraredConfig.RemoteControllers.Remove(rController);
                    break;
                }
            }
            comController.xmlConfiguartion.Save();
            populateIRControllerList(sel_CurrentInfraredController);
        }

        /*
         *  Сохраняем в концигурацию выбранный по умолчанию ИК-пульт
         */
        private void btn_SetDefaultIRC_Click(object sender, EventArgs e)
        {
            if (sel_CurrentInfraredController.SelectedIndex >= 0)
            {
                configDefaults.IRCcontroller = comController.InfraredConfig.Options.CurrentRemoteController.value = sel_CurrentInfraredController.SelectedItem.ToString();
                comController.xmlConfiguartion.Save();
                populateIRControllerList(sel_CurrentInfraredController);
                status_CurrentRC.Text = sel_CurrentInfraredController.SelectedItem.ToString();
            }
        }

        /*
         * Заполнение списка сохраненных в конфиге ИК-пультов
         * Установка фокуса на текущем пульте
         */
        public void populateIRControllerList(ComboBox controllerListBox)
        {
            controllerListBox.Items.Clear();
            comController.LoadConfig();
            foreach (RemoteController storedController in comController.InfraredConfig.RemoteControllers)
            {
                controllerListBox.Items.Add(storedController.name);
                if (storedController.name == configDefaults.IRCcontroller)
                {
                    controllerListBox.SelectedIndex = controllerListBox.FindString(storedController.name);
                }
            }
        }

        /*
         * Переключили селектор ИК-пультов
         */
        private void sel_CurrentInfraredController_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (sel_CurrentInfraredController.SelectedIndex >= 0)
            {
                if (comController.InfraredConfig.RemoteControllers.Count > 0)
                {
                    table_RcButtonActions.Rows.Clear();
                    foreach (Button rcButton in comController.InfraredConfig.RemoteControllers[sel_CurrentInfraredController.SelectedIndex].Buttons)
                    {
                        if (rcButton.name != null && rcButton.code != null)
                        {
                            table_RcButtonActions.Rows.Add();
                            table_RcButtonActions.Rows[rcButton.id].Cells[0].Value = rcButton.name;

                            if (comController.ActionsConfig.Actions.Count > 0) 
                            {
                                foreach (ActionDescriptor cAction in comController.ActionsConfig.Actions)
                                {
                                    DataGridViewComboBoxCell comboBoxCell = (DataGridViewComboBoxCell)(table_RcButtonActions.Rows[rcButton.id].Cells[1]);
                                    comboBoxCell.Items.Add(cAction.name);
                                    if (rcButton.action == cAction.id)
                                    {
                                        comboBoxCell.Value = cAction.name;
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        /*
         * Создаем перехватчик событий изменения выпадающих списков для действий
         */
        private void table_RcButtonActions_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (table_RcButtonActions.CurrentCell.ColumnIndex == 1 && e.Control is ComboBox)
            {
                ComboBox comboBox = e.Control as ComboBox;
                comboBox.SelectedIndexChanged -= LastColumnComboSelectionChanged;
                comboBox.SelectedIndexChanged += LastColumnComboSelectionChanged;
            }
        }

        /*
         * Событие изменения значения выпадающего списка
         * Сохраняем в конфиг значение действия для кнопки
         */
        private void LastColumnComboSelectionChanged(object sender, EventArgs e)
        {
            var currentcell = table_RcButtonActions.CurrentCellAddress;
            var sendingCB = sender as DataGridViewComboBoxEditingControl;
            if (sendingCB.SelectedIndex >= 0)
            {
                string cButton = table_RcButtonActions.Rows[currentcell.Y].Cells[0].Value.ToString();
                Console.WriteLine(cButton);
            }

        }

        #endregion

        #region Методы для вкладки Датчиков температуры

        /*
         * Открытие окна с графиком температур из базы SQLite
         */
        private void btn_Statistics_Click(object sender, EventArgs e)
        {
            TemperatureGraphWindow graphWindow = new TemperatureGraphWindow();
            graphWindow.Show();
        }

        /*
         * Сохранение конфигурации датчиков температуры в xml-файл
         */
        private void btn_SaveTempSettings_Click(object sender, EventArgs e)
        {            
            int defaultAskInterval = Int32.Parse(comController.TemperatureSensorsConfig.Options.askInterval.value);
            int defaultSaveInterval = Int32.Parse(comController.TemperatureSensorsConfig.Options.saveInterval.value);
            int sensorsUpdated = 0;
            bool isAskNumerical = false, isSaveNumerical = false;

            if (table_TempSensors.Rows.Count > 0)
            {
                foreach (DataGridViewRow currentSensorRow in table_TempSensors.Rows)
                {
                    string currentSensorROM = currentSensorRow.Cells[0].Value.ToString();
                    int askInterval = 0, saveInterval = 0;
                    Sensor currentSensor = comController.TemperatureSensorsConfig.Sensors.GetItemByKey(currentSensorROM);
                    if (comController.OWbusSensors[currentSensorROM].Connected == true && currentSensorRow.Cells[1].Value != null)
                    {
                        if (currentSensor == null)
                        {
                            try
                            {
                                comController.TemperatureSensorsConfig.Sensors.Add(
                                    new Sensor
                                    {
                                        ROM = currentSensorROM,
                                        name = currentSensorRow.Cells[1].Value.ToString()
                                    });
                            }
                            catch (Exception)
                            {
                                MessageBox.Show("Ошибка добавления датчика. Проверьте файл конфигурации.", "Ошибка конфигурации XML");
                            }
                            currentSensor = comController.TemperatureSensorsConfig.Sensors.GetItemByKey(currentSensorROM);
                        }
                        currentSensor.name = currentSensorRow.Cells[1].Value.ToString();
                        currentSensorRow.DefaultCellStyle.BackColor = Color.PaleGreen;
                        temperature_chart.Series[currentSensor.ROM].LegendText = currentSensor.name;

                        if (currentSensorRow.Cells[3].Value != null)
                        {
                            isAskNumerical = int.TryParse(currentSensorRow.Cells[3].Value.ToString(), out askInterval);
                        }
                        if (currentSensorRow.Cells[4].Value != null)
                        {
                            isSaveNumerical = int.TryParse(currentSensorRow.Cells[4].Value.ToString(), out saveInterval);
                        }

                        currentSensor.askInterval = !isAskNumerical || askInterval <= 0 ? defaultAskInterval : askInterval;
                        currentSensor.saveInterval = !isSaveNumerical || saveInterval <= 0 ? defaultSaveInterval : saveInterval;
                        currentSensor.dbSave = Convert.ToBoolean(currentSensorRow.Cells[5].Value) ? true : false;
                        currentSensor.drawOnGraph = Convert.ToBoolean(currentSensorRow.Cells[6].Value) ? true : false;

                        if (currentSensor.dbSave && comController.OWbusSensors[currentSensorROM].Connected == true)
                        {
                            int sqlSensorID = comController.dbConnection.UpdateSensor(currentSensor.ROM, currentSensor.name);
                            if (sqlSensorID > 0)
                            {
                                currentSensor.id = sqlSensorID;
                            }
                        }
                        sensorsUpdated++;
                    }

                }
                if (sensorsUpdated > 0)
                {
                    comController.sensorTimersControl(false);
                    comController.xmlConfiguartion.Save();
                    //this.populateTempSensorTable(table_TempSensors);
                    comController.InitSensorTimers();
                }
            }
            else
            {
                MessageBox.Show("Датчики температуры не найдены!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning); 
            }
        }

        /*
         * Вставляет значение температуры указанного датчика в таблицу датчиков
         */
        public void updateTemperatureValues(string sensorRom, float tempValue)
        {

            if (sensorRom != null)
            {
                foreach (DataGridViewRow sensorRow in table_TempSensors.Rows)
                {
                    if (sensorRow.Cells[0].Value.ToString() == sensorRom)
                    {
                        sensorRow.Cells[2].Value = tempValue.ToString("0.0");
                        if (Convert.ToBoolean(sensorRow.Cells[6].Value) == true && temperature_chart.Series.IndexOf(sensorRom) != -1)
                        {
                            temperature_chart.ResetAutoValues();
                            temperature_chart.Series[sensorRom].Points.AddY(tempValue);
                            if (temperature_chart.Series[sensorRom].Points.Count() > Int32.Parse(comController.TemperatureSensorsConfig.Options.TempTableVisibleValuesNumber.value))
                            {
                                temperature_chart.Series[sensorRom].Points.RemoveAt(0);
                            }
                            temperature_chart.Invalidate();
                        }
                    }
                }
            }
        }

        /*
         * Заполнение таблицы температурных датчиков.
         * Создание графиков оперативного мониторинга показания датчиков
         */
        public void populateTempSensorTable(DataGridView sensorTable)
        {
            string sensorName = "";
            string askInterval = "";
            string saveInterval = "";

            bool dbSave = false;
            bool drawOnGraph = true;

            // Очищаем таблицу с датчиками и график температур
            sensorTable.Rows.Clear();
            //temperature_chart.Series.Clear();

            // Загружаем свежую конфигурацию из файла
            comController.LoadConfig();

            /*
             * Пробегаемся по сохраненным в файле конфигурации датчикам и 
             * добавляем их к найденным на шине датчикам (структура OwbusSensors)
             */
            foreach (Sensor storedSensors in comController.TemperatureSensorsConfig.Sensors)
            {
                ComConnectionController.SensorStatus storedStatus = new ComConnectionController.SensorStatus();
                storedStatus.Configured = true;
                storedStatus.Connected = false;
                if (comController.OWbusSensors.ContainsKey(storedSensors.ROM.ToString()))
                {
                    storedStatus.Connected = true;
                    comController.OWbusSensors.Remove(storedSensors.ROM.ToString());
                }
                comController.OWbusSensors.Add(storedSensors.ROM.ToString(), storedStatus);
            }

            /*
             * Проходимся по всей структуре датчиков, наполняем таблицу
             */
            foreach (var _sensor in comController.OWbusSensors)
            {
                //Console.WriteLine("sensor:" + _sensor.Key + " connected:" + _sensor.Value.Connected.ToString() + " configured:" + _sensor.Value.Configured.ToString());
                string sensorROM = _sensor.Key;
                if ((bool)_sensor.Value.Configured == false)
                {
                    sensorName = "Новый датчик";
                    askInterval = comController.TemperatureSensorsConfig.Options.askInterval.value.ToString();
                    saveInterval = comController.TemperatureSensorsConfig.Options.saveInterval.value.ToString();
                    dbSave = false;
                    drawOnGraph = true;
                }
                else
                {
                    sensorName = comController.TemperatureSensorsConfig.Sensors.GetItemByKey(sensorROM).name.ToString();
                    askInterval = comController.TemperatureSensorsConfig.Sensors.GetItemByKey(sensorROM).askInterval != 0 ? comController.TemperatureSensorsConfig.Sensors.GetItemByKey(sensorROM).askInterval.ToString() : comController.TemperatureSensorsConfig.Options.askInterval.value.ToString();
                    saveInterval = comController.TemperatureSensorsConfig.Sensors.GetItemByKey(sensorROM).saveInterval != 0 ? comController.TemperatureSensorsConfig.Sensors.GetItemByKey(sensorROM).saveInterval.ToString() : comController.TemperatureSensorsConfig.Options.saveInterval.value.ToString();
                    dbSave = comController.TemperatureSensorsConfig.Sensors.GetItemByKey(sensorROM).dbSave ? true : false;
                    drawOnGraph = comController.TemperatureSensorsConfig.Sensors.GetItemByKey(sensorROM).drawOnGraph ? true : false;
                }

                sensorTable.Rows.Add(
                    sensorROM,
                    sensorName,
                    "",
                    askInterval,
                    saveInterval,
                    dbSave,
                    drawOnGraph
                    );

                /*
                 * Проверяем, создан ли график температуры нашего датчика, 
                 * если нет - создаем и настраиваем его внешний вид
                 */
                if (temperature_chart.Series.IndexOf(sensorROM) == -1)
                {
                    temperature_chart.Series.Add(sensorROM);
                }
                temperature_chart.Series[sensorROM].LegendText = sensorName;
                temperature_chart.Series[sensorROM].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
                temperature_chart.Series[sensorROM].BorderWidth = 3;

                /*
                 * Раскрашиваем строки таблицы с датчиками
                 * Зеленый - датчик подключен и сконфигурирован
                 * Желтый - датчик подключен, но не сконфигурирован
                 * Красный - датчик сконфигурирован, но не подключен
                 */
                int lasRowIndex = sensorTable.Rows.Count - 1;
                if ((bool)_sensor.Value.Configured == true && (bool)_sensor.Value.Connected == true)
                {
                    sensorTable.Rows[lasRowIndex].DefaultCellStyle.BackColor = Color.PaleGreen;
                }
                else if ((bool)_sensor.Value.Configured == true && (bool)_sensor.Value.Connected == false)
                {
                    sensorTable.Rows[lasRowIndex].DefaultCellStyle.BackColor = Color.OrangeRed;
                }
                else if ((bool)_sensor.Value.Configured == false && (bool)_sensor.Value.Connected == true)
                {
                    sensorTable.Rows[lasRowIndex].DefaultCellStyle.BackColor = Color.Khaki;
                }
            }
        }

        /*
         * Отправка кадра опроса шины датчиков температуры
         */
        private void bts_SensorsLookup_Click(object sender, EventArgs e)
        {
            comController.SendFrame(FrameMarker.TEMPERATURE_ENUM);
        }

        /*
         * Отправка кадра RESET с требованием сброса контроллера
         */
        private void btn_ResetController_Click(object sender, EventArgs e)
        {
            comController.SendFrame(FrameMarker.RESET);
            temperature_chart.Series.Clear();
        }

        #endregion

        #region Методы для главной вкладки
        /*
         * Событие по клику на виджет температуры на главной вкладке
         * Показывает селектор датчиков, скрывает текущее значение температуры
         */
        private void widget_Click(object sender, System.EventArgs e)
        {
            Label widgetCaller = (Label)sender;
            GroupBox widget = (GroupBox)widgetCaller.Parent;
            foreach (Control kid in widget.Controls)
            {
                if (kid.GetType() == typeof(Label))
                {
                    Label widget_value = (Label)kid;
                    widget_value.Hide();
                }
                else if (kid.GetType() == typeof(ComboBox))
                {
                    ComboBox widget_selector = (ComboBox)kid;
                    widget_selector.Show();
                    widget_selector.BringToFront();
                    widget_selector.Select();
                }

            }
        }

        /*
         * Событие при уходе фокуса или мыши с селектора датчиков
         * Скрыват селектор, показывает значение температуры
         */
        private void widget_Selector_Close(object sender, System.EventArgs e)
        {
            ComboBox widgetCaller = (ComboBox)sender;
            GroupBox widget = (GroupBox)widgetCaller.Parent;
            foreach (Control kid in widget.Controls)
            {
                if (kid.GetType() == typeof(Label))
                {
                    Label widget_value = (Label)kid;
                    widget_value.Show();
                    widget_value.BringToFront();
                    widget_value.Select();
                }
                else if (kid.GetType() == typeof(ComboBox))
                {
                    ComboBox widget_selector = (ComboBox)kid;
                    widget_selector.Hide();
                }

            }
        }

        /*
         * Заполняет селекторы датчиков в виджетах на главной
         * Выставляет фокус на датчик выбранный из конфига, если он есть
         * Меняет имя датчика, на выбраный, если он есть в конфиге
         */
        private void populateSensorsList()
        {
            foreach (Control sensorsWidget in group_Temperature_Widgets.Controls)
            {
                if (sensorsWidget.GetType() == typeof(GroupBox))
                {
                    ComboBox widgetSensorSelector = sensorsWidget.Controls.OfType<ComboBox>().First();
                    ComboBox.ObjectCollection sensorsList = new ComboBox.ObjectCollection(widgetSensorSelector);
                    string widgetName = sensorsWidget.Name.ToString();

                    if (comController.TemperatureSensorsConfig.Sensors.Count > 0)
                    {
                        widgetSensorSelector.Items.Clear();
                        foreach (Sensor cSensor in comController.TemperatureSensorsConfig.Sensors)
                        {
                            widgetSensorSelector.Items.Add(new ComboboxItem(cSensor.name, cSensor.ROM));
                        }
                    }

                    Widget cWidget = comController.TemperatureSensorsConfig.Widgets.GetItemByKey(widgetName);
                    if (cWidget != null)
                    {
                        Sensor cSensor = comController.TemperatureSensorsConfig.Sensors.GetItemByKey(cWidget.sensorROM);
                        if (cSensor != null)
                        {
                            sensorsWidget.Text = cSensor.name;
                            widgetSensorSelector.SelectedIndex = widgetSensorSelector.FindStringExact(cSensor.name);
                        }
                    }
                }
            }
        }

        /*
         * Обновление температуры в виджетах на главной вкладке
         */
        private void processWidgetTemperature(object sender, TempValueArrivedArgs e)
        {
            string currentRom = e.ROM.ToString();
            float currentTemp = e.Temperature;
            
            foreach (Control sensorsWidget in group_Temperature_Widgets.Controls)
            {
                if (sensorsWidget.Tag != null && sensorsWidget.Tag.ToString() == currentRom)
                {
                    Label sensorValue = sensorsWidget.Controls.OfType<Label>().First();
                    sensorValue.Text = currentTemp.ToString("00.0") + " ºС";
                }
            }
            
        }

        /*
         * Событие при изменении значения селектора датчиков виджета
         */
        private void widget_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox selector = (ComboBox)sender;
            if (selector.SelectedIndex >= 0)
            {
                ComboboxItem selectedSensor = (ComboboxItem)selector.SelectedItem;
                GroupBox widget = (GroupBox)selector.Parent;
                string _widgetName = widget.Name.ToString();

                widget.Text = selectedSensor.Text;
                widget.Tag = selectedSensor.Value;

                if (comController.TemperatureSensorsConfig.Widgets.GetItemByKey(_widgetName) != null)
                {
                    comController.TemperatureSensorsConfig.Widgets.GetItemByKey(_widgetName).sensorROM = selectedSensor.Value;
                }
                else
                {
                    comController.TemperatureSensorsConfig.Widgets.Add(new Widget { widgetName = _widgetName, sensorROM = selectedSensor.Value });
                }
                comController.xmlConfiguartion.Save();
            }

        }

        #endregion

        #region Методы для вкладки Подсветки
        /*
         * Сигнал выключения подсветки
         */
        private void RGBPower(bool enabled)
        {
            if (enabled && !this.RGBLightPowered)
            {
                this.RGBSetColor(comController.LastColorSelected);
                this.RGBLightPowered = true;
            }
            else if (!enabled && this.RGBLightPowered)
            {
                comController.SendFrame(FrameMarker.RGB_COLOR, comController.HexToByte("000000"));
                this.RGBLightPowered = false;
            }
        }

        /*
         * Выставление подсветки заданного цвета
         * Посылка соответствующего пакета контроллеру
         */
        private string RGBSetColor(Color color)
        {
            string hexColor = color.R.ToString("X2") + color.G.ToString("X2") + color.B.ToString("X2");
            
            comController.SendFrame(FrameMarker.RGB_COLOR, comController.HexToByte(hexColor));
            comController.LastColorSelected = color;
            this.RGBLightPowered = true;
            but_RGBPower.Text = "Выключить";

            return hexColor;
        }


        /*
         * Событие при изменении значения цветового ползунка (любого из трех RGB)
         * Посылка пакета контроллеру. Изменение цвета пробника.
         */
        private void redRgbColorSlider_ValueChanged(object sender, EventArgs e)
        {
            Color resultColor = Color.FromArgb((int)redSlider.Value, (int)greenSlider.Value, (int)blueSlider.Value);
            RGBSetColor(resultColor);
            pan_ColorSample.BackColor = resultColor;
        }

        /*
         * Включение или выключение подсветки.
         * При включении - устанавливается последний использованный цвет, либо цвет по-умолчанию (из конфига)
         */
        private void button1_Click(object sender, EventArgs e)
        {
            if (this.RGBLightPowered == true)
            {
                this.RGBPower(false);
                colorTimer.Enabled = false;
                colorTimer.Stop();
                but_RGBPower.Text = "Включить";
            }
            else
            {
                this.RGBPower(true);
                but_RGBPower.Text = "Выключить";
            }
        }

        /*
         * Событие при выборе цвета из палитры.
         * Отправить цветовой пакет контроллеру
         * Установить цвет пробника.
         */
        private void colorPalette_ColorChanged(object sender, EventArgs e)
        {
            string hexColor = RGBSetColor(colorPalette.Color);
            redSlider.Value = colorPalette.Color.R;
            greenSlider.Value = colorPalette.Color.G;
            blueSlider.Value = colorPalette.Color.B;
            pan_ColorSample.BackColor = colorPalette.Color;
        }

        /*
         * Заполнение селектора режимов подсветки
         */
        private void populateRGBModesList()
        {
            sel_RGBMode.Items.Clear();
            sel_RGBMode.Items.Add(new ComboboxItem ("Один цвет", "singleColor"));
            sel_RGBMode.Items.Add(new ComboboxItem ("Цветовой переход", "colorPreset"));
        }

        /*
         * Событие по изменению селектора режима подсветки
         */
        private void sel_RGBMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            comController.RGBConfig.Options.mode.value = this.configDefaults.RGBmode = ((ComboboxItem)sel_RGBMode.SelectedItem).Value;
            comController.xmlConfiguartion.Save();
        }
        #endregion

        private void button1_Click_1(object sender, EventArgs e)
        {
            //this.startTrans = pan_ColorSample.BackColor;
            this.LightEffect = new RGBcolorPreset(comController.RGBConfig.ColorPresets.GetItemByKey("rainbow"));
            this.LightEffect.MakeTransition(1);
            this.LightEffect.TransitionColorChanged += new RGBcolorPreset.TransitionColorChangedHandler(TransitionColorChanged);
            timer1.Enabled = true;
            timer1.Start();
        }

        private void TransitionColorChanged(object sender, TransitionColorChangedArgs e)
        {
            Color currentColor = e.color;
            
            //RGBSetColor(currentColor);
            Console.WriteLine(currentColor.ToString());

            
            redSlider.Value = currentColor.R;
            greenSlider.Value = currentColor.G;
            blueSlider.Value = currentColor.B;
            

            iter.Text = e.currentColorStateNumber.ToString();
        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            int seconds = Int32.Parse(timeCounter.Text);
            seconds++;
            timeCounter.Text = seconds.ToString();
        }

    }

}
