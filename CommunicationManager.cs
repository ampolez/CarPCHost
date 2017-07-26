using System;
using System.Text;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Configuration;
using MultiControlHost;


//*****************************************************************************************
//                           LICENSE INFORMATION
//*****************************************************************************************
//   PCCom.SerialCommunication Version 1.0.0.0
//   Class file for managing serial port communication
//
//   Copyright (C) 2007  
//   Richard L. McCutchen 
//   Email: richard@psychocoder.net
//   Created: 20OCT07
//
//   This program is free software: you can redistribute it and/or modify
//   it under the terms of the GNU General Public License as published by
//   the Free Software Foundation, either version 3 of the License, or
//   (at your option) any later version.
//
//   This program is distributed in the hope that it will be useful,
//   but WITHOUT ANY WARRANTY; without even the implied warranty of
//   MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//   GNU General Public License for more details.
//
//   You should have received a copy of the GNU General Public License
//   along with this program.  If not, see <http://www.gnu.org/licenses/>.
//*****************************************************************************************
namespace PCComm
{
    /// <summary>
    /// EventArgs used to send bytes recieved on serial port
    /// </summary>
    public class SerialDataEventArgs : EventArgs
    {
        public SerialDataEventArgs(SerialFrame rxFrame)
        {
            Frame = rxFrame;
        }

        /// <summary>
        /// Byte array containing data from serial port
        /// </summary>
        /// 
        public SerialFrame Frame;
    }

    /*
     * Класс для передачи параметров по событию изменения значения температуры
     */
    public class TempValueArrivedArgs : EventArgs
    {
        private float _tempValue = 0;
        private string _sensorRom = string.Empty;

        public float Temperature
        {
            get { return _tempValue; }
        }
        public string ROM 
        {
            get { return _sensorRom; }
        }
        public TempValueArrivedArgs(float tempValue, string sensorRom)
        {
            _sensorRom = sensorRom;
            _tempValue = tempValue;
        }
    }

    /*
     * Класс для описания элементов списка датчиков температуры
     */
    public class ComboboxItem
    {
        public string Text { get; set; }
        public string Value { get; set; }
        public ComboboxItem(string text, string value)
        {
            this.Text = text;
            this.Value = value;
        }

        public override string ToString()
        {
            return Text;
        }
    }

    /*
     * Структурные элементы кадров обмен аданными
     * Заголовки (типы) кадров
     */ 
    public enum FrameMarker 
    {
        UNDEFINED = 0x00,
        ERROR = 0xFF,
        RESET = 0xFC,
        INFRARED = 0x10,
        RESISTIVE = 0x20,
        TEMPERATURE_SENSOR = 0x30,
        TEMPERATURE_ENUM = 0x32,
        RGB_COLOR = 0x40,
        RGB_MODE = 0x41
    };

    /*
     * Структурные элементы кадров обмен аданными
     * Коды ошибок
     */
    public enum ErrorCode
    {
        ERROR_NONE = 0x00,						// Ошибок нет
        ERROR_UNKNOWN = 0xFF,					// Неизвестная ошибка
        ERROR_TEMP_NO_SENSORS = 0x31,			// Датчики температуры не обнаружены
        ERROR_TEMP_CRC = 0x32,					// Ошибка контрольной суммы при обращении к датчику, возможно потеряно соединение
        ERROR_TEMP_MEASURE_FAILED = 0x33,		// Ошибка измерения температуры, возможно короткое замыкание
        ERROR_TEMP_BUS_NO_SENSOR = 0x34,		// Ошибка шины 1-Wire - нет датчиков
        ERROR_TEMP_BUS_DATA = 0x35,				// Ошибка шины 1-Wire - ошибка в полученных данных
        ERROR_RGB_INCORRECT_COLOR_FRAME = 0x41	// Неверный пакет с цветовыми данными	
    }

    /*
     * Класс для работы с таблицей кнопок пультов ДУ
     * Добавляет, утверждает, удаляет и изменяет кнопки, соответствующие пультам ДУ
     */
    public class KeyTable
    {
        public int frameRepeatCount = 3;

        private DataGridView _keyDataTable;
        private DataGridViewRow _selectedKeyProperties;

        private string _selectedKeyCode, _selectedKeyName = string.Empty;
        private int _selectedKeyIndex, _selectedKeyStatus = 0;

        /*
         * Конструктор.
         * Определяет текущую выбранную кнопку в таблице и получает её параметры.
         */
        public KeyTable(DataGridView keyDataTable)
        {
            _keyDataTable = keyDataTable;
            _selectedKeyIndex = _keyDataTable.SelectedCells[0].RowIndex;
            _selectedKeyProperties = _keyDataTable.Rows[_selectedKeyIndex];
            if (_selectedKeyProperties.Cells[0].Value != null)
            {
                _selectedKeyName = _selectedKeyProperties.Cells[0].Value.ToString();
            }
            if (_selectedKeyProperties.Cells[1].Value != null)
            {
                _selectedKeyCode = _selectedKeyProperties.Cells[1].Value.ToString();
            }
            if (_selectedKeyProperties.Cells[2].Value != null)
            {
                _selectedKeyStatus = Convert.ToInt32(_selectedKeyProperties.Cells[2].Value);
            }
        }

        public void PassKeyCode(string keyHEXCode)
        {
            if (_selectedKeyName == string.Empty)
            {
                _selectedKeyName = "Key" + (_selectedKeyIndex + 1).ToString();
            }
            if (_selectedKeyCode == keyHEXCode)
            {
                _selectedKeyStatus++;
            }
            else
            {
                _selectedKeyStatus = 1;
                _selectedKeyCode = keyHEXCode;
            }
            InsertKey(_selectedKeyIndex, _selectedKeyStatus, _selectedKeyName, _selectedKeyCode);
            CheckKeyStatus(_selectedKeyIndex);
        }

        public void InsertKey(int keyIndex, int keyStatus, string keyName, string keyCode)
        {
            if (_keyDataTable.Rows.Count == keyIndex + 1)
            {
                _keyDataTable.Rows.Add();
                _keyDataTable.Rows[keyIndex].Selected = true;
                _keyDataTable.Rows[keyIndex + 1].Selected = false;
            }
            try
            {
                _keyDataTable.Rows[keyIndex].Cells[0].Value = keyName;
                _keyDataTable.Rows[keyIndex].Cells[1].Value = keyCode;
                _keyDataTable.Rows[keyIndex].Cells[2].Value = keyStatus.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        public void CheckKeyStatus(int keyIndex)
        {
            int keyStatus = 1;
            if (_keyDataTable.Rows[keyIndex].Cells[2].Value.ToString() == "OK")
            {
                keyStatus = frameRepeatCount;
            }
            else
            {
                keyStatus = Convert.ToInt32(_keyDataTable.Rows[keyIndex].Cells[2].Value);
            }
            if (keyStatus >= frameRepeatCount)
            {
                _keyDataTable.Rows[keyIndex].DefaultCellStyle.BackColor = Color.YellowGreen;
                //_keyDataTable.Rows[keyIndex].Cells[2].Value = "OK";
                _keyDataTable.Rows[keyIndex].Selected = false;
                _keyDataTable.Rows[++keyIndex].Selected = true;
            } else 
            {
                _keyDataTable.Rows[keyIndex].DefaultCellStyle.BackColor = Color.Yellow;
            }
        }

        public void PassKeyCode(byte[] keyBinCode) {
        }

        public void RemoveKey(byte[] keyCode)
        {
        }

        public void RemoveKey(int keyIndex)
        {
        }

        public void SaveKeyTable()
        {
        }
    }

    public class SerialFrame
    {
        private FrameMarker _Type = FrameMarker.UNDEFINED;
        private ErrorCode _Error = ErrorCode.ERROR_NONE;
        private int _DataSize = 0;
        private byte[] _Data, _RawData;
        private bool _Recognized = false;

        public SerialFrame(byte[] frameData)
        {
            byte[] frameType = frameData.Take(1).ToArray();
            byte[] frameDataSize = { 0 };

            this._RawData = frameData;
            if (frameData != null && frameData.Count() > 0)
            {
                foreach (var frameMarker in Enum.GetValues(typeof(FrameMarker)))
                {
                    if (frameType[0] == (int)frameMarker)
                    {
                        frameDataSize = frameData.Skip(1).Take(1).ToArray();
                        this._Type = (FrameMarker)Enum.Parse(typeof(FrameMarker), frameMarker.ToString());
                        this._DataSize = frameDataSize[0];
                        this._Data = frameData.Skip(2).Take(frameDataSize[0]).ToArray();
                        this._Recognized = true;
                        
                        if (this._Type == FrameMarker.ERROR)
                        {
                            foreach(var errorCode in Enum.GetValues(typeof(ErrorCode))) 
                            {
                                if((int)errorCode == _Data[0]) {
                                    this._Error = (ErrorCode)Enum.Parse(typeof(ErrorCode), _Data[0].ToString());
                                }
                            }
                        }
                        break;
                    }
                }
            }
        }

        #region Frame variables 

        /// <summary>
        /// Свойство для установки и чтения кода ошибки
        /// </summary>
        public ErrorCode Error
        {
            get { return _Error; }
            set { _Error = value; }
        }

        /// <summary>
        /// Свойство для установки и чтения типа кадра
        /// </summary>
        public FrameMarker Type
        {
            get { return _Type; }
            set { _Type = value; }
        }

        /// <summary>
        /// Свойство для получения статуса кадра (распознан или нет)
        /// </summary>
        public bool Recognized
        {
            get { return _Recognized; }
        }

        /// <summary>
        /// Свойство для установки и чтения размера блока данных кадра
        /// </summary>
        public int DataSize
        {
            get { return _DataSize; }
            set { _DataSize = value; }
        }

        /// <summary>
        /// Свойство для установки и чтения данных кадра
        /// </summary>
        public byte[] Data
        {
            get { return _Data; }
            set { _Data = value; }
        }

        /// <summary>
        /// Свойство для установки и чтения всего кадра
        /// </summary>
        public byte[] RawData
        {
            get { return _RawData; }
            set { _RawData = value; }
        }

        #endregion

    }

    public class CommunicationManager : IDisposable
    {
        public event EventHandler<SerialDataEventArgs> NewSerialDataRecieved;

        #region Manager Enums
        /// <summary>
        /// enumeration to hold our transmission types
        /// </summary>
        public enum TransmissionType { Text, Hex };

        /// <summary>
        /// enumeration to hold our message types
        /// </summary>
        public enum MessageType { Incoming, Outgoing, Normal, Warning, Error };

        /// <summary>
        /// enumeration to hold our receiving mode
        /// </summary>
        public enum ReceiveModes { Idle, Learn_IR, Learn_RES };

        #endregion

        #region Manager Variables
        //property variables
        private string _baudRate = string.Empty;
        private string _parity = string.Empty;
        private string _stopBits = string.Empty;
        private string _dataBits = string.Empty;
        private string _portName = string.Empty;
        private TransmissionType _transType;
        private ReceiveModes _receiveMode;
        private RichTextBox _displayWindow;
        //global manager variables
        private Color[] MessageColor = { Color.Blue, Color.Green, Color.Black, Color.Orange, Color.Red };
        private SerialPort comPort = new SerialPort();
        #endregion

        #region Manager Properties
        /// <summary>
        /// Property to hold the Receive Mode
        /// of our manager class
        /// </summary>
        public ReceiveModes ReceiveMode
        {
            get { return _receiveMode; }
            set { _receiveMode = value; }
        }

        /// <summary>
        /// Property to hold the BaudRate
        /// of our manager class
        /// </summary>
        public string BaudRate
        {
            get { return _baudRate; }
            set { _baudRate = value; }
        }

        /// <summary>
        /// property to hold the Parity
        /// of our manager class
        /// </summary>
        public string Parity
        {
            get { return _parity; }
            set { _parity = value; }
        }

        /// <summary>
        /// property to hold the StopBits
        /// of our manager class
        /// </summary>
        public string StopBits
        {
            get { return _stopBits; }
            set { _stopBits = value; }
        }

        /// <summary>
        /// property to hold the DataBits
        /// of our manager class
        /// </summary>
        public string DataBits
        {
            get { return _dataBits; }
            set { _dataBits = value; }
        }

        /// <summary>
        /// property to hold the PortName
        /// of our manager class
        /// </summary>
        public string PortName
        {
            get { return _portName; }
            set { _portName = value; }
        }

        /// <summary>
        /// property to hold our TransmissionType
        /// of our manager class
        /// </summary>
        public TransmissionType CurrentTransmissionType
        {
            get { return _transType; }
            set { _transType = value; }
        }

        /// <summary>
        /// property to hold our display window
        /// value
        /// </summary>
        public RichTextBox DisplayWindow
        {
            get { return _displayWindow; }
            set { _displayWindow = value; }
        }
        #endregion

        #region Manager Constructors
        /// <summary>
        /// Constructor to set the properties of our Manager Class
        /// </summary>
        /// <param name="baud">Desired BaudRate</param>
        /// <param name="par">Desired Parity</param>
        /// <param name="sBits">Desired StopBits</param>
        /// <param name="dBits">Desired DataBits</param>
        /// <param name="name">Desired PortName</param>
        public CommunicationManager(string baud, string par, string sBits, string dBits, string name, RichTextBox rtb)
        {
            _baudRate = baud;
            _parity = par;
            _stopBits = sBits;
            _dataBits = dBits;
            _portName = name;
            _displayWindow = rtb;
            //now add an event handler
            comPort.DataReceived += new SerialDataReceivedEventHandler(comPort_DataReceived);
        }

        /// <summary>
        /// Comstructor to set the properties of our
        /// serial port communicator to nothing
        /// </summary>
        public CommunicationManager()
        {
            _receiveMode = ReceiveModes.Idle;
            _baudRate = string.Empty;
            _parity = string.Empty;
            _stopBits = string.Empty;
            _dataBits = string.Empty;
            _portName = "COM1";
            _displayWindow = null;
            //add event handler
            comPort.DataReceived += new SerialDataReceivedEventHandler(comPort_DataReceived);
        }
        #endregion

        #region Manager Destructor and Port Disposer
        ~CommunicationManager()
        {
            Dispose(false);
        }

        // Call to release serial port
        public void Dispose()
        {
            Dispose(true);
        }

        // Part of basic design pattern for implementing Dispose
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                comPort.DataReceived -= new SerialDataReceivedEventHandler(comPort_DataReceived);
            }
            // Releasing serial port (and other unmanaged objects)
            if (comPort != null)
            {
                if (comPort.IsOpen)
                    comPort.Close();

                comPort.Dispose();
            }
        }
        #endregion

        #region WriteData
        public void WriteData(byte[] msg)
        {
            if (comPort.IsOpen)
            {
                try
                {
                    comPort.Write(msg, 0, msg.Length);
                    comPort.Write("\r");
                    CallBackMy.serialDataTransmittingHandler();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка порта");
                }
            }
             
        }
        #endregion

        #region DisplayData
        /// <summary>
        /// method to display the data to & from the port
        /// on the screen
        /// </summary>
        /// <param name="type">MessageType of the message</param>
        /// <param name="msg">Message to display</param>
        [STAThread]
        private void DisplayData(MessageType type, string msg)
        {
            _displayWindow.Invoke(new EventHandler(delegate
        {
            _displayWindow.SelectedText = string.Empty;
            _displayWindow.SelectionFont = new Font(_displayWindow.SelectionFont, FontStyle.Bold);
            _displayWindow.SelectionColor = MessageColor[(int)type];
            _displayWindow.AppendText(msg);
            _displayWindow.ScrollToCaret();
        }));
        }
        #endregion

        #region OpenPort
        public bool OpenPort()
        {
            try
            {
                if (comPort.IsOpen == true) 
                    comPort.Close();
                //set the properties of our SerialPort Object
                comPort.BaudRate = int.Parse(_baudRate);    //BaudRate
                comPort.DataBits = int.Parse(_dataBits);    //DataBits
                comPort.StopBits = (StopBits)Enum.Parse(typeof(StopBits), _stopBits);    //StopBits
                comPort.Parity = (Parity)Enum.Parse(typeof(Parity), _parity);    //Parity
                comPort.PortName = _portName;   //PortName
                //now open the port
                comPort.Open();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        #endregion

        #region SetParityValues
        public void SetParityValues(object obj)
        {
            foreach (string str in Enum.GetNames(typeof(Parity)))
            {
                ((ComboBox)obj).Items.Add(str);
            }
        }
        #endregion

        #region SetStopBitValues
        public void SetStopBitValues(object obj)
        {
            foreach (string str in Enum.GetNames(typeof(StopBits)))
            {
                ((ComboBox)obj).Items.Add(str);
            }
        }
        #endregion

        #region SetPortNameValues
        public void SetPortNameValues(object obj)
        {

            foreach (string str in SerialPort.GetPortNames())
            {
                ((ComboBox)obj).Items.Add(str);
            }
        }
        #endregion

        #region comPort_DataReceived
        /// <summary>
        /// method that will be called when theres data waiting in the buffer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        public void comPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            byte[] comBuffer = new byte[256];
            try
            {
                int bytesRead = 0;
                var current = comPort.ReadByte();
                while (current != 0xF0)
                {
                    comBuffer[bytesRead] = (byte)current;
                    current = comPort.ReadByte();
                    bytesRead++;
                }

                byte[] frameBuffer = new byte[bytesRead];
                Array.ConstrainedCopy(comBuffer, 0, frameBuffer, 0, bytesRead);
                bytesRead = 0;
                NewSerialDataRecieved(this, new SerialDataEventArgs(new SerialFrame(frameBuffer)));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Исключение: " + ex.Message + "\nОбъект: " + ex.TargetSite.ToString() + "\nДополнительно: " + ex.ToString(), "Ошибка при получении данных из порта");
                return;
            }

        }
        #endregion

        #region IsConnected
        public bool IsConnected()
        {
            try
            {
                return comPort.IsOpen;
            }
            catch (Exception)
            {
                return false;
            }
        }
        #endregion

        #region Close
        public void Close()
        {
            comPort.Close();
        }
        #endregion

        #region HexToByte
        /// <summary>
        /// method to convert hex string into a byte array
        /// </summary>
        /// <param name="msg">string to convert</param>
        /// <returns>a byte array</returns>
        private byte[] HexToByte(string msg)
        {
            //remove any spaces from the string
            msg = msg.Replace(" ", "");
            //create a byte array the length of the
            //divided by 2 (Hex is 2 characters in length)
            byte[] comBuffer = new byte[msg.Length / 2];
            //loop through the length of the provided string
            for (int i = 0; i < msg.Length; i += 2)
                //convert each set of 2 characters to a byte
                //and add to the array
                comBuffer[i / 2] = (byte)Convert.ToByte(msg.Substring(i, 2), 16);
            //return the array
            return comBuffer;
        }
        #endregion

        #region ByteToHex
        /// <summary>
        /// method to convert a byte array into a hex string
        /// </summary>
        /// <param name="comByte">byte array to convert</param>
        /// <returns>a hex string</returns>
        public string ByteToHex(byte[] comByte)
        {
            //create a new StringBuilder object
            StringBuilder builder = new StringBuilder(comByte.Length * 3);
            //loop through each byte in the array
            foreach (byte data in comByte)
                //convert the byte to a string and add to the stringbuilder
                builder.Append(Convert.ToString(data, 16).PadLeft(2, '0'));
            //return the converted value
            return builder.ToString().ToUpper();
        }
        #endregion

    }

    public class ComConnectionController
    {
        public delegate void TempValueArrivedHandler(object sender, TempValueArrivedArgs eventArgs);
        public event TempValueArrivedHandler SensorValueArrived;
        
        public Color LastColorSelected = new Color();

        private string _configFileName = string.Empty;
        public int MaxTempSensorsNumber = 0;
        public int sensorROMsize = 0;
        public bool sensorTimersRunning = false;

        /* 
         * Структура параметров датчиков 
         */
        public struct SensorStatus
        {
            public bool Connected;
            public bool Configured;
            public float Value;
        }

        /*
         * Структура для значений настроек по-умолчанию
         */
        public struct ConfigDefaults
        {
            public string IRCcontroller;
            public string RGBmode;
            public string RGBColor;
        }

        /*
         * Список датчиков, найденных на шине 1-wire
         */
        public Dictionary<string, SensorStatus> OWbusSensors = new Dictionary<string, SensorStatus>();

        /* 
         * Адаптеры для интерфейсов последовательного порта и базы SQLite
         */
        public CommunicationManager Connection = new CommunicationManager();
        public SQLiteAdapter dbConnection = new SQLiteAdapter("temperature.db");

        /* 
         * Интерфейсы для секций конфигурации xml-файла
         */
        private Configuration _xmlConfiguartion;
        private InfraredControllerConfig _InfraredConfig;
        private ResistiveControllerConfig _ResistiveConfig;
        private GeneralDeviceConfig _GeneralConfig;
        private ActionsConfig _ActionsConfig;
        private TemperatureSensorsConfig _TemperatureSensorsConfig;
        private RGBControllerConfig _RGBConfig;

        /* 
         * Таймеры опроса и сохранения температурных данных
         */
        private Timer[] _askTimers;
        private Timer[] _saveTimers;

        /* 
         * Счетчики кадров всех типов 
         */
        public int TX_Frames = 0;
        public int RX_Frames = 0;
        public int IRC_Frames = 0;
        public int RES_Frames = 0;
        public int TEM_Frames = 0;
        public int RGB_Frames = 0;
        public int ERR_Frames = 0;

        /*
         * Конструктор. 
         * Загружает конфиг, создает, если его нет и привязывает его название к глобальному указателю
         */
        public ComConnectionController(string configFileName)
        {
            this._configFileName = configFileName;
            this.LoadConfig();
            this.dbConnection.Open();
            this.dbConnection.PrepareDB();
        }

        /*
         * Проверяем, есть-ли конфиг.
         * Если нет - создаем его и набиваем разделами
         */
        public void LoadConfig()
        {
            try
            {
//                if (!File.Exists(fileMap.ExeConfigFilename))
//                throw new Exception("Configuration file could not be found :" + fileMap.ExeConfigFilename);

                ExeConfigurationFileMap configMap = new ExeConfigurationFileMap();
                configMap.ExeConfigFilename = this._configFileName;
                _xmlConfiguartion = ConfigurationManager.OpenMappedExeConfiguration(configMap, ConfigurationUserLevel.None);
                _InfraredConfig = _xmlConfiguartion.GetSection("infraredControllerConfig") as InfraredControllerConfig;
                _ResistiveConfig = _xmlConfiguartion.GetSection("resistiveControllerConfig") as ResistiveControllerConfig;
                _GeneralConfig = _xmlConfiguartion.GetSection("generalDeviceConfig") as GeneralDeviceConfig;
                _ActionsConfig = _xmlConfiguartion.GetSection("actionsConfig") as ActionsConfig;
                _TemperatureSensorsConfig = xmlConfiguartion.GetSection("temperatureSensorsConfig") as TemperatureSensorsConfig;
                _RGBConfig = xmlConfiguartion.GetSection("RGBControllerConfig") as RGBControllerConfig;
                MaxTempSensorsNumber = Int32.Parse(_TemperatureSensorsConfig.Options.maxDevices.value);
                sensorROMsize = Int32.Parse(_TemperatureSensorsConfig.Options.ROMsize.value.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Отсутствует файл конфигурации!\n" + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); 
            }
        }

        /*
         * Устанавливает соединение с портом в соответствии с настройками из конфига
         * В обычном режиме кидает сообщения с ошибками соединения, в тихом молча завершается.
         */
        public void Connect(bool silentMode = true)
        {
            GeneralDeviceConfig config = _xmlConfiguartion.GetSection("generalDeviceConfig") as GeneralDeviceConfig;
            if (!String.IsNullOrEmpty(config.Connection.PortNumber.value) ||
                !String.IsNullOrEmpty(config.Connection.BaudRate.value) ||
                !String.IsNullOrEmpty(config.Connection.Parity.value) ||
                !String.IsNullOrEmpty(config.Connection.StopBits.value) ||
                !String.IsNullOrEmpty(config.Connection.DataBits.value))
            {
                Connection.PortName = config.Connection.PortNumber.value;
                Connection.BaudRate = config.Connection.BaudRate.value;
                Connection.Parity = config.Connection.Parity.value;
                Connection.StopBits = config.Connection.StopBits.value;
                Connection.DataBits = config.Connection.DataBits.value;
                Connection.CurrentTransmissionType = CommunicationManager.TransmissionType.Hex;
                try
                {
                    Connection.OpenPort();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                if (!silentMode)
                {
                    MessageBox.Show("Не указаны необходимые параметры соединения с устройством!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

        }

        /*
         * Отправить кадр с данными в COM-порт.
         * Агрументы: тип кадра и данные для отправки
         * Формирует пакет содержащий тип кадра, размер блока данных и сами данные
         * Отправлет пакет в порт, если он доступен
         */
        public void SendFrame(FrameMarker frameType, byte[] frameData = null)
        {
            byte[] frame;

            if (frameData != null)
            {
                int dataSize = frameData.Count();
                frame = new byte[dataSize+2];
                frame[1] = (byte)dataSize;
                for (int i = 0; i < dataSize; i++)
                {
                    frame[i+2] = frameData[i];
                }
            }
            else
            {
                frame = new byte[2];
                frame[1] = 0;
            }

            frame[0] = (byte)frameType;
            try
            {
                Connection.WriteData(frame);
                this.TX_Frames++;
            }
            catch (Exception)
            {
                return;
            }
        }

        /*
         * Создает таймеры для отправки кадров опроса датчиков и таймеры сохранения температурных параметров
         */
        public void InitSensorTimers()
        {
            //Random rndSeed = new Random();  // Генератор случайных чисел для "подсаливания" интервала таймеров

            int defaultAskInterval = Int32.Parse(this._TemperatureSensorsConfig.Options.askInterval.value);
            int defaultSaveInterval = Int32.Parse(this._TemperatureSensorsConfig.Options.saveInterval.value);
            int sensorsFound = this.TemperatureSensorsConfig.Sensors.Count;
            int currentSensor = 0, askInterval = 0, saveInterval = 0;

            this._askTimers = new Timer[this.MaxTempSensorsNumber];
            this._saveTimers = new Timer[this.MaxTempSensorsNumber];

            
            if (sensorsFound > 0 && sensorsFound <= this.MaxTempSensorsNumber)
            {             
                foreach (Sensor tSensor in _TemperatureSensorsConfig.Sensors)
                {
                    // Таймеры включаются только для датчиков, подключенных в данный момент
                    if (this.OWbusSensors.Keys.Contains(tSensor.ROM) && this.OWbusSensors[tSensor.ROM].Connected == true)
                    {
                        // Определение таймеров опроса датчиков
                        askInterval = defaultAskInterval;
                        if (tSensor.askInterval > 0)
                        {
                            askInterval = tSensor.askInterval;
                        }
                        _askTimers[currentSensor] = new Timer();
                        _askTimers[currentSensor].Interval = askInterval * 1000; // + rndSeed.Next(10, 200);    // Добавляем немного энтропии для рассинхронизации запросов к разным датчикам
                        _askTimers[currentSensor].Tag = tSensor.ROM.ToString();
                        _askTimers[currentSensor].Enabled = true;
                        _askTimers[currentSensor].Tick += new EventHandler(askTimer_Tick);
                        _askTimers[currentSensor].Start();

                        // Определение таймеров сохранения значений температуры
                        if (tSensor.dbSave == true)
                        {
                            saveInterval = defaultSaveInterval;
                            if (tSensor.saveInterval > 0)
                            {
                                saveInterval = tSensor.saveInterval;
                            }
                            _saveTimers[currentSensor] = new Timer();
                            _saveTimers[currentSensor].Interval = saveInterval * 1000;
                            _saveTimers[currentSensor].Tag = tSensor.ROM.ToString();
                            _saveTimers[currentSensor].Enabled = true;
                            _saveTimers[currentSensor].Tick += new EventHandler(saveTimer_Tick);
                            _saveTimers[currentSensor].Start();
                        }
                        currentSensor++;
                        this.sensorTimersRunning = true;
                    }
                }
            }
        }

        /*
         * Событие по таймеру опроса датчика температуры
         * Отправляем кадр TEMPERATURE_SENSOR
         */
        private void askTimer_Tick(object sender, EventArgs e)
        {
            Timer cTimer = ((Timer)sender);
            if (cTimer != null)
            {
                cTimer.Stop();
                string sensorROM = cTimer.Tag.ToString();
                if (this.OWbusSensors.Keys.Contains(sensorROM) && this.OWbusSensors[sensorROM].Connected == true)
                {
                    SendFrame(FrameMarker.TEMPERATURE_SENSOR, HexToByte(sensorROM));
                }
                cTimer.Start();
            }
        }

        /*
         * Событие по таймеру сохранения температуры
         * Сохраняем значение температуры в бзау SQLite
         */
        private void saveTimer_Tick(object sender, EventArgs e)
        {
            Timer cTimer = ((Timer)sender);
            if (cTimer != null)
            {
                cTimer.Stop();
                string sensorROM = cTimer.Tag.ToString();
                if (this.OWbusSensors.Keys.Contains(sensorROM) && this.OWbusSensors[sensorROM].Connected == true)
                {
                    this.dbConnection.InsertTempValue(this._TemperatureSensorsConfig.Sensors[sensorROM].id, this.OWbusSensors[sensorROM].Value);
                }
                cTimer.Start();
            }
        }

        /*
         * Управление таймерами опроса и сохранения параметров датчиков. 
         * Если isRunning = true, то включает таймеры, иначе - выключает
         */
        public void sensorTimersControl(bool isRunning)
        {
            if (_askTimers != null && _askTimers.Count() > 0)
            {
                foreach (Timer aTimer in _askTimers)
                {
                    if (aTimer != null)
                    {
                        if (!isRunning && aTimer.Enabled)
                        {
                            aTimer.Stop();
                            this.sensorTimersRunning = false;
                        }
                        else
                        {
                            aTimer.Start();
                            this.sensorTimersRunning = true;
                        }
                    }
                }
            }
            if (_saveTimers != null && _saveTimers.Count() > 0)
            {
                foreach (Timer saveTimer in _saveTimers)
                {
                    if (saveTimer != null)
                    {
                        if (!isRunning && saveTimer.Enabled)
                        {
                            saveTimer.Stop();
                            this.sensorTimersRunning = false;
                        }
                        else
                        {
                            saveTimer.Start();
                            this.sensorTimersRunning = true;
                        }
                    }
                }
            }
        }

        /*
         * Разбирает кадр типа TEMPERATURE_SENSOR и получает значение температуры датчика
         */
        public IDictionary<string, float> GetTemperature(SerialFrame frame) {
            IDictionary<string, float> result = new Dictionary<string, float>();

            if (frame.Recognized && frame.Type == FrameMarker.TEMPERATURE_SENSOR)
            {
                try
                {
                    byte[] sensorROM = frame.Data.Take(this.sensorROMsize).ToArray();
                    byte[] tempValue = frame.Data.Skip(this.sensorROMsize).Take(4).ToArray();
                    int pos = 0;
                    int res = 0;

                    foreach (byte by in tempValue)
                    {
                        res |= (int)(by << pos);
                        pos += 8;
                    }

                    if (res > -1000000L && res < 10000000L)
                    {
                        float temperature = (float)res / 10000;
                        result[this.ByteToHex(sensorROM)] = temperature;

                        // Проверка на наличие метода, подписанного на событие обновления температуры
                        if (this.SensorValueArrived != null)
                        {
                            // формирование структуры аргументов для передачи с событием - ROM датчика и его температуры
                            TempValueArrivedArgs sensorArgs = new TempValueArrivedArgs(temperature, this.ByteToHex(sensorROM));

                            // создание события о получении нового значения температуры
                            this.SensorValueArrived(this, sensorArgs);
                        }
                    }
                    else
                    {
                        return null;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Исключение: " + ex.Message + "\nОбъект: " + ex.TargetSite.ToString() + "\nДополнительно: " + ex.ToString(), "Исключение в главном модуле");
                    return null;
                }
            }

            return result;
        }

        /*
         * Разбирает кадр типа TEMPERATURE_ENUM, извлекает значение ROM подключенных датчиков. 
         * Проверяет загруженную xml-конфигурацию на наличие датчиков с указанным ROM
         * Если датчик отсутствует в конфигурации - добавляет его.
         * Возвращает количество датчиков, добавленных в конфигурацию
         */
        public int EnumTempSensors(SerialFrame frame)
        {
            int sensorsFound = 0;
            byte[] sensorROM = { 0x00 };
            int defaultAskInterval = Int32.Parse(_TemperatureSensorsConfig.Options.askInterval.value);
            int defaultSaveInterval = Int32.Parse(_TemperatureSensorsConfig.Options.saveInterval.value); 
            
            SensorStatus cStatus = new SensorStatus();
            cStatus.Connected = false;
            cStatus.Configured = false;

            if (frame.DataSize > 0 && frame.DataSize % sensorROMsize == 0)
            {
                this.LoadConfig();
                if (this.OWbusSensors != null || this.OWbusSensors.Count() > 0)
                {
                    this.OWbusSensors.Clear();
                }

                sensorsFound = frame.DataSize / sensorROMsize;
                if (sensorsFound > MaxTempSensorsNumber)
                {
                    sensorsFound = MaxTempSensorsNumber;
                    MessageBox.Show("Обнаружено слишком много датчиков температуры!\nИзмените максимально разрешенное количество датчиков в настройках.", "Ошибка");
                }
                for (int sensorID = 0; sensorID < sensorsFound; sensorID++)
                {
                    cStatus.Connected = true;
                    cStatus.Configured = false;
                    sensorROM = frame.Data.Skip(sensorID * sensorROMsize).Take(sensorROMsize).ToArray();

                    /* 
                     * Проверяем конфиг на наличие датчиков. 
                     * Если находим датчик с указанным ROM, берем его настройки из конфига
                     */
                    foreach (Sensor _sensor in _TemperatureSensorsConfig.Sensors)
                    {
                        if (_sensor.ROM == ByteToHex(sensorROM))
                        {
                            cStatus.Configured = true;
                            this.OWbusSensors.Add(this.ByteToHex(sensorROM), cStatus);
                            break;
                        }
                    }

                    /* 
                     * Остальные найденные датчики - новые.
                     * Их настройки берем из конфига по-умолчанию
                     */
                    if (!cStatus.Configured)
                    {
                        this.OWbusSensors.Add(this.ByteToHex(sensorROM), cStatus);
                        try
                        {
                            _TemperatureSensorsConfig.Sensors.Add(
                                new Sensor
                                {
                                    ROM = ByteToHex(sensorROM),
                                    name = "Новый датчик",
                                    askInterval = defaultAskInterval,
                                    saveInterval = defaultSaveInterval,
                                    dbSave = false
                                });
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Ошибка добавления датчика. Проверьте файл конфигурации.", "Ошибка конфигурации XML");
                        }
                    }
                }
            }
            else
            {
                this.OWbusSensors.Clear();
            }
            return sensorsFound;
        }
        /*
        public void CreateConfigFile(SampleRunnerOptions options, out string newConfigFilePath)
        {
            newConfigFilePath = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName() + ".config");
            ExeConfigurationFileMap fileMap = new ExeConfigurationFileMap { ExeConfigFilename = newConfigFilePath };
            var config = ConfigurationManager.OpenMappedExeConfiguration(fileMap, ConfigurationUserLevel.None, options.EnablePreloadConfigFileCheckBox);

            // Create configuration
            SchoolRegistrySection section = new SchoolRegistrySection();
            // NOTE: Can really be any name, but the same name must be used when reading.
            config.Sections.Add("schoolRegistrySection", section);

            Professor flimflop = new Professor { Name = "Dr. Flimflop", YearOfBirth = 1968 };
            section.Professors.Add(flimflop);
            Professor mania = new Professor { Name = "Dr. Maniä", YearOfBirth = 1972 };
            section.Professors.Add(mania);

            Student johnson = new Student { Name = "Johnson", YearOfBirth = 1989 };
            section.Students.Add(johnson);
            mania.Students.Add(johnson);

            config.Save();
        }
         */


        public Configuration xmlConfiguartion
        {
            get { return _xmlConfiguartion; }
            set { _xmlConfiguartion = value; }
        }
        public InfraredControllerConfig InfraredConfig
        {
            get { return _InfraredConfig; }
        }
        public ResistiveControllerConfig ResistiveConfig
        {
            get { return _ResistiveConfig; }
        }
        public GeneralDeviceConfig GeneralConfig
        {
            get { return _GeneralConfig; }
        }
        public ActionsConfig ActionsConfig
        {
            get { return _ActionsConfig; }
        }
        public TemperatureSensorsConfig TemperatureSensorsConfig
        {
            get { return _TemperatureSensorsConfig; }
        }       
        public RGBControllerConfig RGBConfig
        {
            get { return _RGBConfig; }
        }
     
        #region HexToByte
        /// <summary>
        /// method to convert hex string into a byte array
        /// </summary>
        /// <param name="msg">string to convert</param>
        /// <returns>a byte array</returns>
        public byte[] HexToByte(string msg)
        {
            //remove any spaces from the string
            msg = msg.Replace(" ", "");
            //create a byte array the length of the
            //divided by 2 (Hex is 2 characters in length)
            byte[] comBuffer = new byte[msg.Length / 2];
            //loop through the length of the provided string
            for (int i = 0; i < msg.Length; i += 2)
                //convert each set of 2 characters to a byte
                //and add to the array
                comBuffer[i / 2] = (byte)Convert.ToByte(msg.Substring(i, 2), 16);
            //return the array
            return comBuffer;
        }
        #endregion

        #region ByteToHex
        /// <summary>
        /// method to convert a byte array into a hex string
        /// </summary>
        /// <param name="comByte">byte array to convert</param>
        /// <returns>a hex string</returns>
        public string ByteToHex(byte[] comByte)
        {
            //create a new StringBuilder object
            StringBuilder builder = new StringBuilder(comByte.Length * 3);
            //loop through each byte in the array
            foreach (byte data in comByte)
                //convert the byte to a string and add to the stringbuilder
                builder.Append(Convert.ToString(data, 16).PadLeft(2, '0'));
            //return the converted value
            return builder.ToString().ToUpper();
        }
        #endregion
    }
}
