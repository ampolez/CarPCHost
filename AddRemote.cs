using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;

using PCComm;

namespace MultiControlHost
{
    public partial class AddRemote : Form
    {
        private ComConnectionController comController = new ComConnectionController("MultiControlHost.exe.config");
        private KeyTable newKeyDataTable;

        private bool _editMode = false;                         // режим редактирования отключен
        private RemoteController _RemoteController = null;      // объект ИК-пульта для режима редактирования

        public AddRemote(string RemoteControllerName = null)
        {
            InitializeComponent();

            // Если указано имя пульта - пробуем открыть окно в режиме редактирования кнопок
            if(!string.IsNullOrEmpty(RemoteControllerName)) 
            {
                // ищем в файле конфигурации пульт с указанным названием
                try 
                {
                    _RemoteController = comController.InfraredConfig.RemoteControllers.GetItemByKey(RemoteControllerName);
                } 
                catch (Exception) {
                    return;
                }
                
                // включаем режим редактирования
                _editMode = true;
            }

            // подключаемся к потоку данных, приходящих в порт
            comController.Connection.NewSerialDataRecieved += new EventHandler<SerialDataEventArgs>(SerialFrameReceived);
        }

        public void SerialFrameReceived(object sender, SerialDataEventArgs e)
        {
            newKeyDataTable = new KeyTable(table_RemoteKeys);
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new EventHandler<SerialDataEventArgs>(SerialFrameReceived), new object[] { sender, e });
                return;
            }
            string keyCode_fresh = comController.ByteToHex(e.Frame.Data).ToString();
            scan_Test.Text = "Код кнопки: "+ keyCode_fresh;

            // Вмешиваемся, только если прием идет в режиме обучения ИК-кодам
            if (comController.Connection.ReceiveMode == CommunicationManager.ReceiveModes.Learn_IR)
            {
                // Обрабатываем только кадры от ИК-приемника
                if (e.Frame.Type == FrameMarker.INFRARED)
                {
                    newKeyDataTable.PassKeyCode(keyCode_fresh);
                }
            }
        }

        private void AddRemote_Load(object sender, EventArgs e)
        {
            // если включен режим редактирования кнопок, загружаем их из конфига и забиваем в таблицу
            if (_editMode)
            {
                txt_ControllerName.Enabled = false;
                txt_ControllerName.Text = _RemoteController.name;
                if (_RemoteController.Buttons.Count > 0)
                {
                    foreach (Button rcButton in _RemoteController.Buttons)
                    {
                        if (!string.IsNullOrEmpty(rcButton.name))
                        {
                            table_RemoteKeys.Rows.Add();
                            table_RemoteKeys.Rows[rcButton.id].Cells[0].Value = rcButton.name;
                            table_RemoteKeys.Rows[rcButton.id].Cells[1].Value = rcButton.code;
                            table_RemoteKeys.Rows[rcButton.id].Cells[2].Value = "3";
                        }
                    }
                }
            }

            comController.Connect();    // подключаемся к порту        
            comController.Connection.ReceiveMode = CommunicationManager.ReceiveModes.Learn_IR;  // переходим в режим обучения ИК-командам
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddRemote_FormClosing(object sender, FormClosingEventArgs e)
        {
            comController.Connection.Close();
            CallBackMy.addRemoteWindowClosingHandler();
            CallBackMy.callbackEventHandler();
        }

        private void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int currentRow = table_RemoteKeys.SelectedCells[0].RowIndex;
            if (!table_RemoteKeys.Rows[currentRow].IsNewRow)
            {
                table_RemoteKeys.Rows.RemoveAt(currentRow);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int totalKeys = table_RemoteKeys.Rows.Count - 1;
            int verifiedKeys = 0;
            bool hasUniqueName = true;

            if (!String.IsNullOrEmpty(txt_ControllerName.Text))
            {
                foreach (RemoteController storedController in comController.InfraredConfig.RemoteControllers)
                {
                    if (storedController.name == txt_ControllerName.Text)
                    {
                        if (!_editMode)
                        {
                            hasUniqueName = false;
                            MessageBox.Show("Пульт управления с таким именем уже есть в конфигурации!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            break;
                        }
                        else
                        {
                            hasUniqueName = true;
                            comController.InfraredConfig.RemoteControllers.Remove(_RemoteController);
                            break;
                        }
                    }
                }
                if(hasUniqueName) {
                    RemoteController newController = new RemoteController();
                    if (!_editMode)
                    {
                        newController.name = txt_ControllerName.Text;
                    }
                    else
                    {
                        newController.name = "tmp_" + txt_ControllerName.Text;
                    }
                    foreach (DataGridViewRow row in table_RemoteKeys.Rows)
                    {
                        if (!row.IsNewRow)
                        {
                            if (row.Cells[1].Value != null)
                            {
                                if (!String.IsNullOrEmpty(row.Cells[0].Value.ToString()) && Convert.ToInt32(row.Cells[2].Value) >= newKeyDataTable.frameRepeatCount)
                                {
                                    newController.Buttons.Add(new Button { id = row.Index, name = row.Cells[0].Value.ToString(), code = row.Cells[1].Value.ToString() });
                                    verifiedKeys++;
                                }
                            }
                        }
                    }
                    if(verifiedKeys == totalKeys && totalKeys > 0) {
                        if (_editMode)
                        {
                            comController.xmlConfiguartion.Save();
                            newController.name = txt_ControllerName.Text;
                        }
                        comController.InfraredConfig.RemoteControllers.Add(newController);
                        comController.xmlConfiguartion.Save();
                        this.Close();
                    }
                    else if (verifiedKeys != totalKeys)
                    {
                       DialogResult dialogResult = MessageBox.Show("Не все кнопки пульта имеют имя или подтверждение!\nХотите сохранить только подтверждённые?" , "Предупреждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question); 
                       if(dialogResult == System.Windows.Forms.DialogResult.Yes) {
                           if (_editMode)
                           {
                               comController.xmlConfiguartion.Save();
                               newController.name = txt_ControllerName.Text;
                           }
                           comController.InfraredConfig.RemoteControllers.Add(newController);
                           comController.xmlConfiguartion.Save();
                           this.Close();
                       }
                    }
                    else if (totalKeys <= 0)
                    {
                        MessageBox.Show("Добавьте значения кодов для кнопок!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning); 
                    }
                }
            }
            else
            {
                MessageBox.Show("Укажите название пульта управления!" , "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning); 
            }
         }

    }
}
