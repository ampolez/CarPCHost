using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using PCComm;

namespace MultiControlHost
{
    public partial class ConnectionOptionsWindow : Form
    {
        private ComConnectionController comController = new ComConnectionController("MultiControlHost.exe.config");
        private GeneralDeviceConfig config;

        private string transType = string.Empty;

         public ConnectionOptionsWindow()
        {
            InitializeComponent();
            comController.Connection.NewSerialDataRecieved += new EventHandler<SerialDataEventArgs>(SerialFrameReceived);
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            config = comController.xmlConfiguartion.GetSection("generalDeviceConfig") as GeneralDeviceConfig;
            LoadValues();
            SetDefaults();
            SetControlState();
        }

        public void SerialFrameReceived(object sender, SerialDataEventArgs e)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new EventHandler<SerialDataEventArgs>(SerialFrameReceived), new object[] { sender, e });
                return;
            }
            if(e.Frame.Recognized)
            {
                txt_Log.AppendText("Кадр: " + e.Frame.Type.ToString() + " Размер данных: " + e.Frame.DataSize.ToString() + " Данные: " + comController.ByteToHex(e.Frame.Data).ToString() + "\n");
            }
            else
            {
                txt_Log.AppendText("Сырые данные: " + comController.ByteToHex(e.Frame.RawData).ToString() + "\n");
            }

        }

        private void cmdOpen_Click(object sender, EventArgs e)
        {
            if (comController.Connection.IsConnected())
            {
                comController.Connection.Close();
                cmdOpen.Text = "Подключиться";
                txt_Log.AppendText("Соединение разорвано!\n\n");
            }
            else
            {
                comController.Connection.PortName = cboPort.Text;
                comController.Connection.Parity = cboParity.Text;
                comController.Connection.StopBits = cboStop.Text;
                comController.Connection.DataBits = cboData.Text;
                comController.Connection.BaudRate = cboBaud.Text;
                comController.Connection.DisplayWindow = txt_Log;
                try
                {
                    comController.Connection.OpenPort();
                    cmdOpen.Text = "Отключиться";
                    txt_Log.AppendText("Соединение с портом " + cboPort.Text + " установлено на скорости " + cboBaud.Text + " бод.\n");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        /// <summary>
        /// Method to initialize serial port
        /// values to standard defaults
        /// </summary>
        private void SetDefaults()
        {
            cboPort.Text = config.Connection.PortNumber.value;
            cboBaud.Text = config.Connection.BaudRate.value;
            cboParity.Text = config.Connection.Parity.value;
            cboStop.Text = config.Connection.StopBits.value;
            cboData.Text = config.Connection.DataBits.value;
        }

        /// <summary>
        /// methos to load our serial
        /// port option values
        /// </summary>
        private void LoadValues()
        {
            comController.Connection.SetPortNameValues(cboPort);
            comController.Connection.SetParityValues(cboParity);
            comController.Connection.SetStopBitValues(cboStop);
        }

        /// <summary>
        /// method to set the state of controls
        /// when the form first loads
        /// </summary>
        private void SetControlState()
        {
            cmdSend.Enabled = false;
        }

        private void cmdSend_Click(object sender, EventArgs e)
        {
            //comController.Connection.WriteData(txtSend.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            config.Connection.PortNumber.value = cboPort.Text;
            config.Connection.BaudRate.value = cboBaud.Text;
            config.Connection.Parity.value = cboParity.Text;
            config.Connection.StopBits.value = cboStop.Text;
            config.Connection.DataBits.value = cboData.Text;

            //Console.WriteLine(config.Connection.BaudRate.value);
            comController.xmlConfiguartion.Save();

            btn_SaveSettings.Enabled = false;
        }

        private void EnableSaving(object sender, EventArgs e)
        {
            btn_SaveSettings.Enabled = true;
        }

        private void ConnectionOptionsWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            comController.Connection.Close();
            CallBackMy.callbackEventHandler();
        }

    }
}