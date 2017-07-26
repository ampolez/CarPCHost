namespace MultiControlHost
{
    partial class MainWindow
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend4 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.LegendItem legendItem4 = new System.Windows.Forms.DataVisualization.Charting.LegendItem();
            System.Windows.Forms.DataVisualization.Charting.LegendCell legendCell7 = new System.Windows.Forms.DataVisualization.Charting.LegendCell();
            System.Windows.Forms.DataVisualization.Charting.LegendCell legendCell8 = new System.Windows.Forms.DataVisualization.Charting.LegendCell();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.MainStatusBar = new System.Windows.Forms.StatusStrip();
            this.status_Connection = new System.Windows.Forms.ToolStripStatusLabel();
            this.status_Error = new System.Windows.Forms.ToolStripStatusLabel();
            this.status_TX = new System.Windows.Forms.ToolStripStatusLabel();
            this.status_RX = new System.Windows.Forms.ToolStripStatusLabel();
            this.status_IRC = new System.Windows.Forms.ToolStripStatusLabel();
            this.status_RES = new System.Windows.Forms.ToolStripStatusLabel();
            this.status_TEM = new System.Windows.Forms.ToolStripStatusLabel();
            this.status_RGB = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.status_CurrentRC = new System.Windows.Forms.ToolStripStatusLabel();
            this.timer_ConnectionCheck = new System.Windows.Forms.Timer(this.components);
            this.tab_Peripherals = new System.Windows.Forms.TabControl();
            this.tab_MAIN = new System.Windows.Forms.TabPage();
            this.group_Temperature_Widgets = new System.Windows.Forms.GroupBox();
            this.widget_Sensor1 = new System.Windows.Forms.GroupBox();
            this.widget_Sensor1_Selector = new System.Windows.Forms.ComboBox();
            this.widget_Sensor1_Value = new System.Windows.Forms.Label();
            this.widget_Sensor4 = new System.Windows.Forms.GroupBox();
            this.widget_Sensor4_Selector = new System.Windows.Forms.ComboBox();
            this.widget_Sensor4_Value = new System.Windows.Forms.Label();
            this.widget_Sensor2 = new System.Windows.Forms.GroupBox();
            this.widget_Sensor2_Selector = new System.Windows.Forms.ComboBox();
            this.widget_Sensor2_Value = new System.Windows.Forms.Label();
            this.widget_Sensor3 = new System.Windows.Forms.GroupBox();
            this.widget_Sensor3_Selector = new System.Windows.Forms.ComboBox();
            this.widget_Sensor3_Value = new System.Windows.Forms.Label();
            this.tab_RESISTIVE = new System.Windows.Forms.TabPage();
            this.tab_INFRARED = new System.Windows.Forms.TabPage();
            this.table_RcButtonActions = new System.Windows.Forms.DataGridView();
            this.rc_ButtonName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rc_ButtonActionVaule = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.sel_CurrentInfraredController = new System.Windows.Forms.ComboBox();
            this.btn_SetDefaultIRC = new System.Windows.Forms.Button();
            this.btn_AddRemote = new System.Windows.Forms.Button();
            this.btn_RemoveRemote = new System.Windows.Forms.Button();
            this.btn_ModifyRemote = new System.Windows.Forms.Button();
            this.tab_RGB = new System.Windows.Forms.TabPage();
            this.iter = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.sel_RGBMode = new System.Windows.Forms.ComboBox();
            this.but_RGBPower = new System.Windows.Forms.Button();
            this.pan_ColorSample = new System.Windows.Forms.Panel();
            this.colorPalette = new Cyotek.Windows.Forms.ColorGrid();
            this.greenSlider = new Cyotek.Windows.Forms.RgbaColorSlider();
            this.blueSlider = new Cyotek.Windows.Forms.RgbaColorSlider();
            this.redSlider = new Cyotek.Windows.Forms.RgbaColorSlider();
            this.tab_TEMPERATURE = new System.Windows.Forms.TabPage();
            this.btn_Statistics = new System.Windows.Forms.Button();
            this.bts_SensorsLookup = new System.Windows.Forms.Button();
            this.btn_SaveTempSettings = new System.Windows.Forms.Button();
            this.temperature_chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.btn_ResetController = new System.Windows.Forms.Button();
            this.table_TempSensors = new System.Windows.Forms.DataGridView();
            this.sensorROM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sensorName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sensorValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.askPeriod = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.storeFrequency = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.isStored = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.chartPlor = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.timer_Blink_RX = new System.Windows.Forms.Timer(this.components);
            this.timer_Blink_TX = new System.Windows.Forms.Timer(this.components);
            this.timer_Blink_Frame = new System.Windows.Forms.Timer(this.components);
            this.status_ToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.colorTimer = new System.Windows.Forms.Timer(this.components);
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timeCounter = new System.Windows.Forms.Label();
            this.MainStatusBar.SuspendLayout();
            this.tab_Peripherals.SuspendLayout();
            this.tab_MAIN.SuspendLayout();
            this.group_Temperature_Widgets.SuspendLayout();
            this.widget_Sensor1.SuspendLayout();
            this.widget_Sensor4.SuspendLayout();
            this.widget_Sensor2.SuspendLayout();
            this.widget_Sensor3.SuspendLayout();
            this.tab_INFRARED.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.table_RcButtonActions)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.tab_RGB.SuspendLayout();
            this.tab_TEMPERATURE.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.temperature_chart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.table_TempSensors)).BeginInit();
            this.SuspendLayout();
            // 
            // MainStatusBar
            // 
            this.MainStatusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.status_Connection,
            this.status_Error,
            this.status_TX,
            this.status_RX,
            this.status_IRC,
            this.status_RES,
            this.status_TEM,
            this.status_RGB,
            this.toolStripStatusLabel3,
            this.status_CurrentRC});
            this.MainStatusBar.Location = new System.Drawing.Point(0, 538);
            this.MainStatusBar.Name = "MainStatusBar";
            this.MainStatusBar.ShowItemToolTips = true;
            this.MainStatusBar.Size = new System.Drawing.Size(784, 24);
            this.MainStatusBar.TabIndex = 17;
            this.MainStatusBar.Text = "statusStrip1";
            // 
            // status_Connection
            // 
            this.status_Connection.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.status_Connection.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.status_Connection.BorderStyle = System.Windows.Forms.Border3DStyle.Adjust;
            this.status_Connection.Margin = new System.Windows.Forms.Padding(5, 3, 0, 2);
            this.status_Connection.Name = "status_Connection";
            this.status_Connection.Size = new System.Drawing.Size(110, 19);
            this.status_Connection.Text = "Нет подключения";
            this.status_Connection.Click += new System.EventHandler(this.status_Connection_Click);
            // 
            // status_Error
            // 
            this.status_Error.BackColor = System.Drawing.Color.Gainsboro;
            this.status_Error.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.status_Error.BorderStyle = System.Windows.Forms.Border3DStyle.Adjust;
            this.status_Error.Margin = new System.Windows.Forms.Padding(8, 3, 0, 2);
            this.status_Error.Name = "status_Error";
            this.status_Error.Size = new System.Drawing.Size(31, 19);
            this.status_Error.Text = "ERR";
            this.status_Error.ToolTipText = "ролд";
            // 
            // status_TX
            // 
            this.status_TX.BackColor = System.Drawing.Color.Gainsboro;
            this.status_TX.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.status_TX.BorderStyle = System.Windows.Forms.Border3DStyle.Adjust;
            this.status_TX.Margin = new System.Windows.Forms.Padding(8, 3, 0, 2);
            this.status_TX.Name = "status_TX";
            this.status_TX.Size = new System.Drawing.Size(25, 19);
            this.status_TX.Text = "TX";
            // 
            // status_RX
            // 
            this.status_RX.BackColor = System.Drawing.Color.Gainsboro;
            this.status_RX.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.status_RX.BorderStyle = System.Windows.Forms.Border3DStyle.Adjust;
            this.status_RX.Margin = new System.Windows.Forms.Padding(1, 3, 0, 2);
            this.status_RX.Name = "status_RX";
            this.status_RX.Size = new System.Drawing.Size(25, 19);
            this.status_RX.Text = "RX";
            // 
            // status_IRC
            // 
            this.status_IRC.BackColor = System.Drawing.Color.Gainsboro;
            this.status_IRC.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.status_IRC.BorderStyle = System.Windows.Forms.Border3DStyle.Adjust;
            this.status_IRC.Margin = new System.Windows.Forms.Padding(8, 3, 0, 2);
            this.status_IRC.Name = "status_IRC";
            this.status_IRC.Size = new System.Drawing.Size(29, 19);
            this.status_IRC.Text = "IRC";
            // 
            // status_RES
            // 
            this.status_RES.BackColor = System.Drawing.Color.Gainsboro;
            this.status_RES.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.status_RES.BorderStyle = System.Windows.Forms.Border3DStyle.Adjust;
            this.status_RES.Margin = new System.Windows.Forms.Padding(1, 3, 0, 2);
            this.status_RES.Name = "status_RES";
            this.status_RES.Size = new System.Drawing.Size(30, 19);
            this.status_RES.Text = "RES";
            // 
            // status_TEM
            // 
            this.status_TEM.BackColor = System.Drawing.Color.Gainsboro;
            this.status_TEM.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.status_TEM.BorderStyle = System.Windows.Forms.Border3DStyle.Adjust;
            this.status_TEM.Margin = new System.Windows.Forms.Padding(1, 3, 0, 2);
            this.status_TEM.Name = "status_TEM";
            this.status_TEM.Size = new System.Drawing.Size(35, 19);
            this.status_TEM.Text = "TEM";
            // 
            // status_RGB
            // 
            this.status_RGB.BackColor = System.Drawing.Color.Gainsboro;
            this.status_RGB.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.status_RGB.BorderStyle = System.Windows.Forms.Border3DStyle.Adjust;
            this.status_RGB.Margin = new System.Windows.Forms.Padding(1, 3, 0, 2);
            this.status_RGB.Name = "status_RGB";
            this.status_RGB.Size = new System.Drawing.Size(33, 19);
            this.status_RGB.Text = "RGB";
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Margin = new System.Windows.Forms.Padding(8, 3, 0, 2);
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(62, 19);
            this.toolStripStatusLabel3.Text = "ИК-пульт:";
            // 
            // status_CurrentRC
            // 
            this.status_CurrentRC.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.status_CurrentRC.Name = "status_CurrentRC";
            this.status_CurrentRC.Size = new System.Drawing.Size(68, 19);
            this.status_CurrentRC.Text = "не выбран";
            // 
            // timer_ConnectionCheck
            // 
            this.timer_ConnectionCheck.Enabled = true;
            this.timer_ConnectionCheck.Interval = 500;
            this.timer_ConnectionCheck.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // tab_Peripherals
            // 
            this.tab_Peripherals.Controls.Add(this.tab_MAIN);
            this.tab_Peripherals.Controls.Add(this.tab_RESISTIVE);
            this.tab_Peripherals.Controls.Add(this.tab_INFRARED);
            this.tab_Peripherals.Controls.Add(this.tab_RGB);
            this.tab_Peripherals.Controls.Add(this.tab_TEMPERATURE);
            this.tab_Peripherals.Controls.Add(this.tabPage1);
            this.tab_Peripherals.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tab_Peripherals.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tab_Peripherals.Location = new System.Drawing.Point(0, 0);
            this.tab_Peripherals.Multiline = true;
            this.tab_Peripherals.Name = "tab_Peripherals";
            this.tab_Peripherals.Padding = new System.Drawing.Point(20, 3);
            this.tab_Peripherals.SelectedIndex = 0;
            this.tab_Peripherals.Size = new System.Drawing.Size(784, 562);
            this.tab_Peripherals.TabIndex = 18;
            this.tab_Peripherals.Selected += new System.Windows.Forms.TabControlEventHandler(this.tab_Peripherals_Selected);
            // 
            // tab_MAIN
            // 
            this.tab_MAIN.Controls.Add(this.group_Temperature_Widgets);
            this.tab_MAIN.Location = new System.Drawing.Point(4, 29);
            this.tab_MAIN.Name = "tab_MAIN";
            this.tab_MAIN.Size = new System.Drawing.Size(776, 529);
            this.tab_MAIN.TabIndex = 4;
            this.tab_MAIN.Text = "Главная";
            this.tab_MAIN.UseVisualStyleBackColor = true;
            // 
            // group_Temperature_Widgets
            // 
            this.group_Temperature_Widgets.Controls.Add(this.widget_Sensor1);
            this.group_Temperature_Widgets.Controls.Add(this.widget_Sensor4);
            this.group_Temperature_Widgets.Controls.Add(this.widget_Sensor2);
            this.group_Temperature_Widgets.Controls.Add(this.widget_Sensor3);
            this.group_Temperature_Widgets.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.group_Temperature_Widgets.Location = new System.Drawing.Point(6, 5);
            this.group_Temperature_Widgets.Name = "group_Temperature_Widgets";
            this.group_Temperature_Widgets.Size = new System.Drawing.Size(765, 85);
            this.group_Temperature_Widgets.TabIndex = 2;
            this.group_Temperature_Widgets.TabStop = false;
            // 
            // widget_Sensor1
            // 
            this.widget_Sensor1.Controls.Add(this.widget_Sensor1_Selector);
            this.widget_Sensor1.Controls.Add(this.widget_Sensor1_Value);
            this.widget_Sensor1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.widget_Sensor1.Location = new System.Drawing.Point(5, 11);
            this.widget_Sensor1.Name = "widget_Sensor1";
            this.widget_Sensor1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.widget_Sensor1.Size = new System.Drawing.Size(180, 67);
            this.widget_Sensor1.TabIndex = 0;
            this.widget_Sensor1.TabStop = false;
            this.widget_Sensor1.Text = "Датчик №1";
            // 
            // widget_Sensor1_Selector
            // 
            this.widget_Sensor1_Selector.BackColor = System.Drawing.SystemColors.Window;
            this.widget_Sensor1_Selector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.widget_Sensor1_Selector.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.widget_Sensor1_Selector.FormattingEnabled = true;
            this.widget_Sensor1_Selector.Location = new System.Drawing.Point(6, 25);
            this.widget_Sensor1_Selector.Name = "widget_Sensor1_Selector";
            this.widget_Sensor1_Selector.Size = new System.Drawing.Size(168, 28);
            this.widget_Sensor1_Selector.TabIndex = 2;
            this.widget_Sensor1_Selector.Visible = false;
            this.widget_Sensor1_Selector.SelectedIndexChanged += new System.EventHandler(this.widget_SelectedIndexChanged);
            this.widget_Sensor1_Selector.Leave += new System.EventHandler(this.widget_Selector_Close);
            this.widget_Sensor1_Selector.MouseLeave += new System.EventHandler(this.widget_Selector_Close);
            // 
            // widget_Sensor1_Value
            // 
            this.widget_Sensor1_Value.AutoSize = true;
            this.widget_Sensor1_Value.Font = new System.Drawing.Font("Verdana", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.widget_Sensor1_Value.Location = new System.Drawing.Point(23, 22);
            this.widget_Sensor1_Value.Name = "widget_Sensor1_Value";
            this.widget_Sensor1_Value.Size = new System.Drawing.Size(126, 35);
            this.widget_Sensor1_Value.TabIndex = 0;
            this.widget_Sensor1_Value.Text = "ПУСТО";
            this.widget_Sensor1_Value.Click += new System.EventHandler(this.widget_Click);
            // 
            // widget_Sensor4
            // 
            this.widget_Sensor4.Controls.Add(this.widget_Sensor4_Selector);
            this.widget_Sensor4.Controls.Add(this.widget_Sensor4_Value);
            this.widget_Sensor4.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.widget_Sensor4.Location = new System.Drawing.Point(579, 11);
            this.widget_Sensor4.Name = "widget_Sensor4";
            this.widget_Sensor4.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.widget_Sensor4.Size = new System.Drawing.Size(180, 67);
            this.widget_Sensor4.TabIndex = 1;
            this.widget_Sensor4.TabStop = false;
            this.widget_Sensor4.Text = "Датчик №4";
            // 
            // widget_Sensor4_Selector
            // 
            this.widget_Sensor4_Selector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.widget_Sensor4_Selector.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.widget_Sensor4_Selector.FormattingEnabled = true;
            this.widget_Sensor4_Selector.Location = new System.Drawing.Point(6, 25);
            this.widget_Sensor4_Selector.Name = "widget_Sensor4_Selector";
            this.widget_Sensor4_Selector.Size = new System.Drawing.Size(168, 28);
            this.widget_Sensor4_Selector.TabIndex = 3;
            this.widget_Sensor4_Selector.Visible = false;
            this.widget_Sensor4_Selector.SelectedIndexChanged += new System.EventHandler(this.widget_SelectedIndexChanged);
            this.widget_Sensor4_Selector.Leave += new System.EventHandler(this.widget_Selector_Close);
            this.widget_Sensor4_Selector.MouseLeave += new System.EventHandler(this.widget_Selector_Close);
            // 
            // widget_Sensor4_Value
            // 
            this.widget_Sensor4_Value.AutoSize = true;
            this.widget_Sensor4_Value.Font = new System.Drawing.Font("Verdana", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.widget_Sensor4_Value.Location = new System.Drawing.Point(24, 22);
            this.widget_Sensor4_Value.Name = "widget_Sensor4_Value";
            this.widget_Sensor4_Value.Size = new System.Drawing.Size(126, 35);
            this.widget_Sensor4_Value.TabIndex = 0;
            this.widget_Sensor4_Value.Text = "ПУСТО";
            this.widget_Sensor4_Value.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.widget_Sensor4_Value.Click += new System.EventHandler(this.widget_Click);
            // 
            // widget_Sensor2
            // 
            this.widget_Sensor2.Controls.Add(this.widget_Sensor2_Selector);
            this.widget_Sensor2.Controls.Add(this.widget_Sensor2_Value);
            this.widget_Sensor2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.widget_Sensor2.Location = new System.Drawing.Point(197, 11);
            this.widget_Sensor2.Name = "widget_Sensor2";
            this.widget_Sensor2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.widget_Sensor2.Size = new System.Drawing.Size(180, 67);
            this.widget_Sensor2.TabIndex = 1;
            this.widget_Sensor2.TabStop = false;
            this.widget_Sensor2.Text = "Датчик №2";
            // 
            // widget_Sensor2_Selector
            // 
            this.widget_Sensor2_Selector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.widget_Sensor2_Selector.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.widget_Sensor2_Selector.FormattingEnabled = true;
            this.widget_Sensor2_Selector.Location = new System.Drawing.Point(6, 25);
            this.widget_Sensor2_Selector.Name = "widget_Sensor2_Selector";
            this.widget_Sensor2_Selector.Size = new System.Drawing.Size(168, 28);
            this.widget_Sensor2_Selector.TabIndex = 3;
            this.widget_Sensor2_Selector.Visible = false;
            this.widget_Sensor2_Selector.SelectedIndexChanged += new System.EventHandler(this.widget_SelectedIndexChanged);
            this.widget_Sensor2_Selector.Leave += new System.EventHandler(this.widget_Selector_Close);
            this.widget_Sensor2_Selector.MouseLeave += new System.EventHandler(this.widget_Selector_Close);
            // 
            // widget_Sensor2_Value
            // 
            this.widget_Sensor2_Value.AutoSize = true;
            this.widget_Sensor2_Value.Font = new System.Drawing.Font("Verdana", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.widget_Sensor2_Value.Location = new System.Drawing.Point(23, 22);
            this.widget_Sensor2_Value.Name = "widget_Sensor2_Value";
            this.widget_Sensor2_Value.Size = new System.Drawing.Size(126, 35);
            this.widget_Sensor2_Value.TabIndex = 0;
            this.widget_Sensor2_Value.Text = "ПУСТО";
            this.widget_Sensor2_Value.Click += new System.EventHandler(this.widget_Click);
            // 
            // widget_Sensor3
            // 
            this.widget_Sensor3.Controls.Add(this.widget_Sensor3_Selector);
            this.widget_Sensor3.Controls.Add(this.widget_Sensor3_Value);
            this.widget_Sensor3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.widget_Sensor3.Location = new System.Drawing.Point(388, 11);
            this.widget_Sensor3.Name = "widget_Sensor3";
            this.widget_Sensor3.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.widget_Sensor3.Size = new System.Drawing.Size(180, 67);
            this.widget_Sensor3.TabIndex = 1;
            this.widget_Sensor3.TabStop = false;
            this.widget_Sensor3.Text = "Датчик №3";
            // 
            // widget_Sensor3_Selector
            // 
            this.widget_Sensor3_Selector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.widget_Sensor3_Selector.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.widget_Sensor3_Selector.FormattingEnabled = true;
            this.widget_Sensor3_Selector.Location = new System.Drawing.Point(6, 25);
            this.widget_Sensor3_Selector.Name = "widget_Sensor3_Selector";
            this.widget_Sensor3_Selector.Size = new System.Drawing.Size(168, 28);
            this.widget_Sensor3_Selector.TabIndex = 3;
            this.widget_Sensor3_Selector.Visible = false;
            this.widget_Sensor3_Selector.SelectedIndexChanged += new System.EventHandler(this.widget_SelectedIndexChanged);
            this.widget_Sensor3_Selector.Leave += new System.EventHandler(this.widget_Selector_Close);
            this.widget_Sensor3_Selector.MouseLeave += new System.EventHandler(this.widget_Selector_Close);
            // 
            // widget_Sensor3_Value
            // 
            this.widget_Sensor3_Value.AutoSize = true;
            this.widget_Sensor3_Value.Font = new System.Drawing.Font("Verdana", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.widget_Sensor3_Value.Location = new System.Drawing.Point(23, 22);
            this.widget_Sensor3_Value.Name = "widget_Sensor3_Value";
            this.widget_Sensor3_Value.Size = new System.Drawing.Size(126, 35);
            this.widget_Sensor3_Value.TabIndex = 0;
            this.widget_Sensor3_Value.Text = "ПУСТО";
            this.widget_Sensor3_Value.Click += new System.EventHandler(this.widget_Click);
            // 
            // tab_RESISTIVE
            // 
            this.tab_RESISTIVE.Location = new System.Drawing.Point(4, 29);
            this.tab_RESISTIVE.Name = "tab_RESISTIVE";
            this.tab_RESISTIVE.Padding = new System.Windows.Forms.Padding(3);
            this.tab_RESISTIVE.Size = new System.Drawing.Size(776, 529);
            this.tab_RESISTIVE.TabIndex = 1;
            this.tab_RESISTIVE.Text = "Рулевые кнопки";
            this.tab_RESISTIVE.UseVisualStyleBackColor = true;
            // 
            // tab_INFRARED
            // 
            this.tab_INFRARED.Controls.Add(this.table_RcButtonActions);
            this.tab_INFRARED.Controls.Add(this.groupBox1);
            this.tab_INFRARED.Location = new System.Drawing.Point(4, 29);
            this.tab_INFRARED.Name = "tab_INFRARED";
            this.tab_INFRARED.Padding = new System.Windows.Forms.Padding(3);
            this.tab_INFRARED.Size = new System.Drawing.Size(776, 529);
            this.tab_INFRARED.TabIndex = 0;
            this.tab_INFRARED.Text = "ИК-Пульт";
            this.tab_INFRARED.UseVisualStyleBackColor = true;
            // 
            // table_RcButtonActions
            // 
            this.table_RcButtonActions.AllowUserToAddRows = false;
            this.table_RcButtonActions.AllowUserToDeleteRows = false;
            this.table_RcButtonActions.AllowUserToResizeColumns = false;
            this.table_RcButtonActions.AllowUserToResizeRows = false;
            this.table_RcButtonActions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.table_RcButtonActions.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.rc_ButtonName,
            this.rc_ButtonActionVaule});
            this.table_RcButtonActions.Location = new System.Drawing.Point(316, 11);
            this.table_RcButtonActions.Name = "table_RcButtonActions";
            this.table_RcButtonActions.RowHeadersVisible = false;
            this.table_RcButtonActions.RowTemplate.Height = 30;
            this.table_RcButtonActions.Size = new System.Drawing.Size(452, 458);
            this.table_RcButtonActions.TabIndex = 6;
            this.table_RcButtonActions.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.table_RcButtonActions_EditingControlShowing);
            // 
            // rc_ButtonName
            // 
            this.rc_ButtonName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rc_ButtonName.DefaultCellStyle = dataGridViewCellStyle10;
            this.rc_ButtonName.HeaderText = "Кнопка";
            this.rc_ButtonName.Name = "rc_ButtonName";
            this.rc_ButtonName.ReadOnly = true;
            this.rc_ButtonName.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.rc_ButtonName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // rc_ButtonActionVaule
            // 
            this.rc_ButtonActionVaule.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.rc_ButtonActionVaule.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
            this.rc_ButtonActionVaule.HeaderText = "Действие";
            this.rc_ButtonActionVaule.Name = "rc_ButtonActionVaule";
            this.rc_ButtonActionVaule.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.sel_CurrentInfraredController);
            this.groupBox1.Controls.Add(this.btn_SetDefaultIRC);
            this.groupBox1.Controls.Add(this.btn_AddRemote);
            this.groupBox1.Controls.Add(this.btn_RemoveRemote);
            this.groupBox1.Controls.Add(this.btn_ModifyRemote);
            this.groupBox1.Location = new System.Drawing.Point(8, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(302, 463);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Конфигурация ИК-пульта";
            // 
            // sel_CurrentInfraredController
            // 
            this.sel_CurrentInfraredController.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.sel_CurrentInfraredController.Font = new System.Drawing.Font("Microsoft Sans Serif", 17.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.sel_CurrentInfraredController.Location = new System.Drawing.Point(15, 30);
            this.sel_CurrentInfraredController.Name = "sel_CurrentInfraredController";
            this.sel_CurrentInfraredController.Size = new System.Drawing.Size(272, 37);
            this.sel_CurrentInfraredController.TabIndex = 0;
            this.sel_CurrentInfraredController.SelectedIndexChanged += new System.EventHandler(this.sel_CurrentInfraredController_SelectedIndexChanged);
            // 
            // btn_SetDefaultIRC
            // 
            this.btn_SetDefaultIRC.Location = new System.Drawing.Point(15, 73);
            this.btn_SetDefaultIRC.Name = "btn_SetDefaultIRC";
            this.btn_SetDefaultIRC.Size = new System.Drawing.Size(272, 38);
            this.btn_SetDefaultIRC.TabIndex = 4;
            this.btn_SetDefaultIRC.Text = "Использовать по умолчанию";
            this.btn_SetDefaultIRC.UseVisualStyleBackColor = true;
            this.btn_SetDefaultIRC.Click += new System.EventHandler(this.btn_SetDefaultIRC_Click);
            // 
            // btn_AddRemote
            // 
            this.btn_AddRemote.Location = new System.Drawing.Point(15, 161);
            this.btn_AddRemote.Name = "btn_AddRemote";
            this.btn_AddRemote.Size = new System.Drawing.Size(272, 38);
            this.btn_AddRemote.TabIndex = 1;
            this.btn_AddRemote.Text = "Добавить новый пульт";
            this.btn_AddRemote.UseVisualStyleBackColor = true;
            this.btn_AddRemote.Click += new System.EventHandler(this.btn_AddRemote_Click);
            // 
            // btn_RemoveRemote
            // 
            this.btn_RemoveRemote.Location = new System.Drawing.Point(159, 117);
            this.btn_RemoveRemote.Name = "btn_RemoveRemote";
            this.btn_RemoveRemote.Size = new System.Drawing.Size(128, 38);
            this.btn_RemoveRemote.TabIndex = 3;
            this.btn_RemoveRemote.Text = "Удалить";
            this.btn_RemoveRemote.UseVisualStyleBackColor = true;
            this.btn_RemoveRemote.Click += new System.EventHandler(this.btn_RemoveRemote_Click);
            // 
            // btn_ModifyRemote
            // 
            this.btn_ModifyRemote.Location = new System.Drawing.Point(15, 117);
            this.btn_ModifyRemote.Name = "btn_ModifyRemote";
            this.btn_ModifyRemote.Size = new System.Drawing.Size(128, 38);
            this.btn_ModifyRemote.TabIndex = 2;
            this.btn_ModifyRemote.Text = "Изменить";
            this.btn_ModifyRemote.UseVisualStyleBackColor = true;
            this.btn_ModifyRemote.Click += new System.EventHandler(this.btn_ModifyRemote_Click);
            // 
            // tab_RGB
            // 
            this.tab_RGB.Controls.Add(this.timeCounter);
            this.tab_RGB.Controls.Add(this.iter);
            this.tab_RGB.Controls.Add(this.button1);
            this.tab_RGB.Controls.Add(this.sel_RGBMode);
            this.tab_RGB.Controls.Add(this.but_RGBPower);
            this.tab_RGB.Controls.Add(this.pan_ColorSample);
            this.tab_RGB.Controls.Add(this.colorPalette);
            this.tab_RGB.Controls.Add(this.greenSlider);
            this.tab_RGB.Controls.Add(this.blueSlider);
            this.tab_RGB.Controls.Add(this.redSlider);
            this.tab_RGB.Location = new System.Drawing.Point(4, 29);
            this.tab_RGB.Name = "tab_RGB";
            this.tab_RGB.Size = new System.Drawing.Size(776, 529);
            this.tab_RGB.TabIndex = 2;
            this.tab_RGB.Text = "Подсветка";
            this.tab_RGB.UseVisualStyleBackColor = true;
            // 
            // iter
            // 
            this.iter.AutoSize = true;
            this.iter.Location = new System.Drawing.Point(559, 22);
            this.iter.Name = "iter";
            this.iter.Size = new System.Drawing.Size(18, 20);
            this.iter.TabIndex = 12;
            this.iter.Text = "0";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(506, 9);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(47, 39);
            this.button1.TabIndex = 10;
            this.button1.Text = "A";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // sel_RGBMode
            // 
            this.sel_RGBMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.sel_RGBMode.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.sel_RGBMode.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.sel_RGBMode.FormattingEnabled = true;
            this.sel_RGBMode.Location = new System.Drawing.Point(201, 9);
            this.sel_RGBMode.Name = "sel_RGBMode";
            this.sel_RGBMode.Size = new System.Drawing.Size(287, 37);
            this.sel_RGBMode.TabIndex = 9;
            this.sel_RGBMode.SelectedIndexChanged += new System.EventHandler(this.sel_RGBMode_SelectedIndexChanged);
            // 
            // but_RGBPower
            // 
            this.but_RGBPower.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.but_RGBPower.Location = new System.Drawing.Point(8, 6);
            this.but_RGBPower.Name = "but_RGBPower";
            this.but_RGBPower.Size = new System.Drawing.Size(158, 42);
            this.but_RGBPower.TabIndex = 8;
            this.but_RGBPower.Text = "Включить";
            this.but_RGBPower.UseVisualStyleBackColor = true;
            this.but_RGBPower.Click += new System.EventHandler(this.button1_Click);
            // 
            // pan_ColorSample
            // 
            this.pan_ColorSample.BackColor = System.Drawing.Color.Black;
            this.pan_ColorSample.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pan_ColorSample.Location = new System.Drawing.Point(671, 11);
            this.pan_ColorSample.Name = "pan_ColorSample";
            this.pan_ColorSample.Size = new System.Drawing.Size(97, 31);
            this.pan_ColorSample.TabIndex = 6;
            // 
            // colorPalette
            // 
            this.colorPalette.AutoFit = true;
            this.colorPalette.AutoSize = false;
            this.colorPalette.BackColor = System.Drawing.Color.Transparent;
            this.colorPalette.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.colorPalette.CellSize = new System.Drawing.Size(22, 23);
            this.colorPalette.Columns = 30;
            this.colorPalette.Location = new System.Drawing.Point(8, 231);
            this.colorPalette.Name = "colorPalette";
            this.colorPalette.Palette = Cyotek.Windows.Forms.ColorPalette.Standard256;
            this.colorPalette.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.colorPalette.Size = new System.Drawing.Size(760, 271);
            this.colorPalette.TabIndex = 5;
            this.colorPalette.ColorChanged += new System.EventHandler(this.colorPalette_ColorChanged);
            // 
            // greenSlider
            // 
            this.greenSlider.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.greenSlider.Channel = Cyotek.Windows.Forms.RgbaChannel.Green;
            this.greenSlider.Location = new System.Drawing.Point(8, 114);
            this.greenSlider.Name = "greenSlider";
            this.greenSlider.Size = new System.Drawing.Size(760, 50);
            this.greenSlider.TabIndex = 4;
            this.greenSlider.ValueChanged += new System.EventHandler(this.redRgbColorSlider_ValueChanged);
            // 
            // blueSlider
            // 
            this.blueSlider.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.blueSlider.Channel = Cyotek.Windows.Forms.RgbaChannel.Blue;
            this.blueSlider.Location = new System.Drawing.Point(8, 168);
            this.blueSlider.Name = "blueSlider";
            this.blueSlider.Size = new System.Drawing.Size(760, 50);
            this.blueSlider.TabIndex = 2;
            this.blueSlider.ValueChanged += new System.EventHandler(this.redRgbColorSlider_ValueChanged);
            // 
            // redSlider
            // 
            this.redSlider.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.redSlider.Location = new System.Drawing.Point(8, 60);
            this.redSlider.Name = "redSlider";
            this.redSlider.Size = new System.Drawing.Size(760, 50);
            this.redSlider.TabIndex = 1;
            this.redSlider.ValueChanged += new System.EventHandler(this.redRgbColorSlider_ValueChanged);
            // 
            // tab_TEMPERATURE
            // 
            this.tab_TEMPERATURE.Controls.Add(this.btn_Statistics);
            this.tab_TEMPERATURE.Controls.Add(this.bts_SensorsLookup);
            this.tab_TEMPERATURE.Controls.Add(this.btn_SaveTempSettings);
            this.tab_TEMPERATURE.Controls.Add(this.temperature_chart);
            this.tab_TEMPERATURE.Controls.Add(this.btn_ResetController);
            this.tab_TEMPERATURE.Controls.Add(this.table_TempSensors);
            this.tab_TEMPERATURE.Location = new System.Drawing.Point(4, 29);
            this.tab_TEMPERATURE.Name = "tab_TEMPERATURE";
            this.tab_TEMPERATURE.Size = new System.Drawing.Size(776, 529);
            this.tab_TEMPERATURE.TabIndex = 3;
            this.tab_TEMPERATURE.Text = "Температура";
            this.tab_TEMPERATURE.UseVisualStyleBackColor = true;
            // 
            // btn_Statistics
            // 
            this.btn_Statistics.Location = new System.Drawing.Point(584, 457);
            this.btn_Statistics.Name = "btn_Statistics";
            this.btn_Statistics.Size = new System.Drawing.Size(188, 44);
            this.btn_Statistics.TabIndex = 3;
            this.btn_Statistics.Text = "Графики за период";
            this.btn_Statistics.UseVisualStyleBackColor = true;
            this.btn_Statistics.Click += new System.EventHandler(this.btn_Statistics_Click);
            // 
            // bts_SensorsLookup
            // 
            this.bts_SensorsLookup.Location = new System.Drawing.Point(3, 457);
            this.bts_SensorsLookup.Name = "bts_SensorsLookup";
            this.bts_SensorsLookup.Size = new System.Drawing.Size(188, 44);
            this.bts_SensorsLookup.TabIndex = 0;
            this.bts_SensorsLookup.Text = "Искать датчики";
            this.bts_SensorsLookup.UseVisualStyleBackColor = true;
            this.bts_SensorsLookup.Click += new System.EventHandler(this.bts_SensorsLookup_Click);
            // 
            // btn_SaveTempSettings
            // 
            this.btn_SaveTempSettings.Location = new System.Drawing.Point(197, 457);
            this.btn_SaveTempSettings.Name = "btn_SaveTempSettings";
            this.btn_SaveTempSettings.Size = new System.Drawing.Size(188, 44);
            this.btn_SaveTempSettings.TabIndex = 1;
            this.btn_SaveTempSettings.Text = "Сохранить данные";
            this.btn_SaveTempSettings.UseVisualStyleBackColor = true;
            this.btn_SaveTempSettings.Click += new System.EventHandler(this.btn_SaveTempSettings_Click);
            // 
            // temperature_chart
            // 
            this.temperature_chart.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.temperature_chart.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.temperature_chart.BorderSkin.BackColor = System.Drawing.Color.Transparent;
            this.temperature_chart.BorderSkin.BorderColor = System.Drawing.Color.Transparent;
            this.temperature_chart.BorderSkin.PageColor = System.Drawing.Color.Transparent;
            chartArea4.AxisX.Enabled = System.Windows.Forms.DataVisualization.Charting.AxisEnabled.True;
            chartArea4.AxisX.IsLabelAutoFit = false;
            chartArea4.AxisX.IsStartedFromZero = false;
            chartArea4.AxisX.LabelStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            chartArea4.AxisX.MajorGrid.Interval = 0D;
            chartArea4.AxisX.MajorGrid.IntervalOffset = 0D;
            chartArea4.AxisX.MajorGrid.LineColor = System.Drawing.Color.DimGray;
            chartArea4.AxisX.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash;
            chartArea4.AxisX.MajorTickMark.Interval = 0D;
            chartArea4.AxisX.MajorTickMark.IntervalOffset = 0D;
            chartArea4.AxisX.MajorTickMark.IntervalOffsetType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Seconds;
            chartArea4.AxisX.MajorTickMark.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Seconds;
            chartArea4.AxisX.MajorTickMark.LineColor = System.Drawing.Color.Red;
            chartArea4.AxisX.MaximumAutoSize = 40F;
            chartArea4.AxisX.MinorGrid.Enabled = true;
            chartArea4.AxisX.MinorGrid.LineColor = System.Drawing.Color.Gainsboro;
            chartArea4.AxisX.MinorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dot;
            chartArea4.AxisX.ScrollBar.Size = 20D;
            chartArea4.AxisX.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            chartArea4.AxisX2.IsMarginVisible = false;
            chartArea4.AxisX2.MajorGrid.Interval = 0D;
            chartArea4.AxisX2.MajorGrid.IntervalOffset = 0D;
            chartArea4.AxisX2.MajorGrid.IntervalOffsetType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Seconds;
            chartArea4.AxisX2.MajorGrid.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Seconds;
            chartArea4.AxisX2.MajorGrid.LineColor = System.Drawing.Color.OrangeRed;
            chartArea4.AxisX2.MaximumAutoSize = 90F;
            chartArea4.AxisX2.MinorGrid.IntervalOffsetType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Seconds;
            chartArea4.AxisX2.MinorGrid.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Seconds;
            chartArea4.AxisX2.MinorGrid.LineColor = System.Drawing.Color.Chartreuse;
            chartArea4.AxisY.Interval = 1D;
            chartArea4.AxisY.IsStartedFromZero = false;
            chartArea4.AxisY.LabelStyle.Format = "0";
            chartArea4.AxisY.MajorGrid.Interval = 0D;
            chartArea4.AxisY.MajorGrid.IntervalOffset = 0D;
            chartArea4.AxisY.MajorGrid.LineColor = System.Drawing.Color.DimGray;
            chartArea4.AxisY.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash;
            chartArea4.AxisY.MaximumAutoSize = 95F;
            chartArea4.AxisY.MinorGrid.Enabled = true;
            chartArea4.AxisY.MinorGrid.LineColor = System.Drawing.Color.Gainsboro;
            chartArea4.AxisY.MinorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dot;
            chartArea4.AxisY2.Enabled = System.Windows.Forms.DataVisualization.Charting.AxisEnabled.False;
            chartArea4.AxisY2.MaximumAutoSize = 95F;
            chartArea4.BorderColor = System.Drawing.Color.Transparent;
            chartArea4.BorderWidth = 5;
            chartArea4.CursorX.IsUserEnabled = true;
            chartArea4.CursorX.IsUserSelectionEnabled = true;
            chartArea4.Name = "tempSensorPlotting";
            chartArea4.Position.Auto = false;
            chartArea4.Position.Height = 94F;
            chartArea4.Position.Width = 100F;
            this.temperature_chart.ChartAreas.Add(chartArea4);
            legend4.Alignment = System.Drawing.StringAlignment.Far;
            legendCell7.CellType = System.Windows.Forms.DataVisualization.Charting.LegendCellType.SeriesSymbol;
            legendCell7.Name = "Cell1";
            legendCell7.Text = "New";
            legendCell8.CellType = System.Windows.Forms.DataVisualization.Charting.LegendCellType.SeriesSymbol;
            legendCell8.Name = "Cell2";
            legendCell8.Text = "324";
            legendItem4.Cells.Add(legendCell7);
            legendItem4.Cells.Add(legendCell8);
            legendItem4.ImageStyle = System.Windows.Forms.DataVisualization.Charting.LegendImageStyle.Line;
            legendItem4.MarkerBorderWidth = 3;
            legendItem4.Name = "2134";
            legend4.CustomItems.Add(legendItem4);
            legend4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            legend4.IsTextAutoFit = false;
            legend4.ItemColumnSpacing = 10;
            legend4.LegendStyle = System.Windows.Forms.DataVisualization.Charting.LegendStyle.Row;
            legend4.MaximumAutoSize = 100F;
            legend4.Name = "SensorNames";
            legend4.Position.Auto = false;
            legend4.Position.Height = 6F;
            legend4.Position.Width = 100F;
            legend4.Position.Y = 93F;
            legend4.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.temperature_chart.Legends.Add(legend4);
            this.temperature_chart.Location = new System.Drawing.Point(-14, 229);
            this.temperature_chart.Name = "temperature_chart";
            this.temperature_chart.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Pastel;
            this.temperature_chart.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.temperature_chart.Size = new System.Drawing.Size(784, 222);
            this.temperature_chart.TabIndex = 3;
            this.temperature_chart.Text = "chart1";
            // 
            // btn_ResetController
            // 
            this.btn_ResetController.Location = new System.Drawing.Point(391, 457);
            this.btn_ResetController.Name = "btn_ResetController";
            this.btn_ResetController.Size = new System.Drawing.Size(188, 44);
            this.btn_ResetController.TabIndex = 2;
            this.btn_ResetController.Text = "Сброс контроллера";
            this.btn_ResetController.UseVisualStyleBackColor = true;
            this.btn_ResetController.Click += new System.EventHandler(this.btn_ResetController_Click);
            // 
            // table_TempSensors
            // 
            this.table_TempSensors.AllowUserToAddRows = false;
            this.table_TempSensors.AllowUserToDeleteRows = false;
            this.table_TempSensors.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.table_TempSensors.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle11;
            this.table_TempSensors.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.table_TempSensors.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.sensorROM,
            this.sensorName,
            this.sensorValue,
            this.askPeriod,
            this.storeFrequency,
            this.isStored,
            this.chartPlor});
            this.table_TempSensors.Dock = System.Windows.Forms.DockStyle.Top;
            this.table_TempSensors.Location = new System.Drawing.Point(0, 0);
            this.table_TempSensors.Name = "table_TempSensors";
            this.table_TempSensors.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.table_TempSensors.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.table_TempSensors.RowHeadersVisible = false;
            this.table_TempSensors.RowTemplate.Height = 30;
            this.table_TempSensors.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.table_TempSensors.Size = new System.Drawing.Size(776, 226);
            this.table_TempSensors.TabIndex = 0;
            // 
            // sensorROM
            // 
            this.sensorROM.HeaderText = "ROM датчика";
            this.sensorROM.Name = "sensorROM";
            this.sensorROM.ReadOnly = true;
            this.sensorROM.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.sensorROM.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.sensorROM.Width = 170;
            // 
            // sensorName
            // 
            this.sensorName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.sensorName.HeaderText = "Название";
            this.sensorName.Name = "sensorName";
            this.sensorName.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.sensorName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // sensorValue
            // 
            this.sensorValue.HeaderText = "T, ºС";
            this.sensorValue.Name = "sensorValue";
            this.sensorValue.ReadOnly = true;
            this.sensorValue.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.sensorValue.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.sensorValue.Width = 70;
            // 
            // askPeriod
            // 
            this.askPeriod.HeaderText = "Частота опроса, c";
            this.askPeriod.Name = "askPeriod";
            this.askPeriod.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.askPeriod.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // storeFrequency
            // 
            this.storeFrequency.HeaderText = "Частота записи, c";
            this.storeFrequency.Name = "storeFrequency";
            this.storeFrequency.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.storeFrequency.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // isStored
            // 
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle12.NullValue = false;
            this.isStored.DefaultCellStyle = dataGridViewCellStyle12;
            this.isStored.HeaderText = "В базу";
            this.isStored.Name = "isStored";
            this.isStored.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.isStored.Width = 70;
            // 
            // chartPlor
            // 
            this.chartPlor.HeaderText = "График";
            this.chartPlor.Name = "chartPlor";
            this.chartPlor.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.chartPlor.Width = 80;
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(776, 529);
            this.tabPage1.TabIndex = 5;
            this.tabPage1.Text = "Настройки";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // timer_Blink_RX
            // 
            this.timer_Blink_RX.Tick += new System.EventHandler(this.timer_Blink_Tick);
            // 
            // timer_Blink_TX
            // 
            this.timer_Blink_TX.Tick += new System.EventHandler(this.timer_Blink_TX_Tick);
            // 
            // timer_Blink_Frame
            // 
            this.timer_Blink_Frame.Tick += new System.EventHandler(this.timer_Blink_Frame_Tick);
            // 
            // colorTimer
            // 
            this.colorTimer.Interval = 50;
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick_1);
            // 
            // timeCounter
            // 
            this.timeCounter.AutoSize = true;
            this.timeCounter.Location = new System.Drawing.Point(609, 22);
            this.timeCounter.Name = "timeCounter";
            this.timeCounter.Size = new System.Drawing.Size(18, 20);
            this.timeCounter.TabIndex = 13;
            this.timeCounter.Text = "0";
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.MainStatusBar);
            this.Controls.Add(this.tab_Peripherals);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Name = "MainWindow";
            this.Text = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainWindow_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.MainStatusBar.ResumeLayout(false);
            this.MainStatusBar.PerformLayout();
            this.tab_Peripherals.ResumeLayout(false);
            this.tab_MAIN.ResumeLayout(false);
            this.group_Temperature_Widgets.ResumeLayout(false);
            this.widget_Sensor1.ResumeLayout(false);
            this.widget_Sensor1.PerformLayout();
            this.widget_Sensor4.ResumeLayout(false);
            this.widget_Sensor4.PerformLayout();
            this.widget_Sensor2.ResumeLayout(false);
            this.widget_Sensor2.PerformLayout();
            this.widget_Sensor3.ResumeLayout(false);
            this.widget_Sensor3.PerformLayout();
            this.tab_INFRARED.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.table_RcButtonActions)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.tab_RGB.ResumeLayout(false);
            this.tab_RGB.PerformLayout();
            this.tab_TEMPERATURE.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.temperature_chart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.table_TempSensors)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip MainStatusBar;
        private System.Windows.Forms.ToolStripStatusLabel status_Connection;
        private System.Windows.Forms.ToolStripStatusLabel status_TX;
        private System.Windows.Forms.ToolStripStatusLabel status_RX;
        private System.Windows.Forms.ToolStripStatusLabel status_IRC;
        private System.Windows.Forms.Timer timer_ConnectionCheck;
        private System.Windows.Forms.TabControl tab_Peripherals;
        private System.Windows.Forms.TabPage tab_INFRARED;
        private System.Windows.Forms.TabPage tab_RESISTIVE;
        private System.Windows.Forms.Button bts_SensorsLookup;
        private System.Windows.Forms.Timer timer_Blink_RX;
        private System.Windows.Forms.ToolStripStatusLabel status_RES;
        private System.Windows.Forms.ToolStripStatusLabel status_TEM;
        private System.Windows.Forms.ToolStripStatusLabel status_RGB;
        private System.Windows.Forms.Timer timer_Blink_TX;
        private System.Windows.Forms.Timer timer_Blink_Frame;
        private System.Windows.Forms.TabPage tab_RGB;
        private System.Windows.Forms.TabPage tab_MAIN;
        private System.Windows.Forms.TabPage tab_TEMPERATURE;
        private System.Windows.Forms.ComboBox sel_CurrentInfraredController;
        private System.Windows.Forms.Button btn_AddRemote;
        private System.Windows.Forms.Button btn_RemoveRemote;
        private System.Windows.Forms.Button btn_ModifyRemote;
        private System.Windows.Forms.Button btn_SetDefaultIRC;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView table_RcButtonActions;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripStatusLabel status_CurrentRC;
        private System.Windows.Forms.DataGridViewTextBoxColumn rc_ButtonName;
        private System.Windows.Forms.DataGridViewComboBoxColumn rc_ButtonActionVaule;
        private System.Windows.Forms.DataGridView table_TempSensors;
        private System.Windows.Forms.Button btn_SaveTempSettings;
        private System.Windows.Forms.Button btn_ResetController;
        private System.Windows.Forms.ToolStripStatusLabel status_Error;
        private System.Windows.Forms.ToolTip status_ToolTip;
        private System.Windows.Forms.DataVisualization.Charting.Chart temperature_chart;
        private System.Windows.Forms.DataGridViewTextBoxColumn sensorROM;
        private System.Windows.Forms.DataGridViewTextBoxColumn sensorName;
        private System.Windows.Forms.DataGridViewTextBoxColumn sensorValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn askPeriod;
        private System.Windows.Forms.DataGridViewTextBoxColumn storeFrequency;
        private System.Windows.Forms.DataGridViewCheckBoxColumn isStored;
        private System.Windows.Forms.DataGridViewCheckBoxColumn chartPlor;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button btn_Statistics;
        private System.Windows.Forms.GroupBox widget_Sensor1;
        private System.Windows.Forms.Label widget_Sensor1_Value;
        private System.Windows.Forms.GroupBox widget_Sensor4;
        private System.Windows.Forms.Label widget_Sensor4_Value;
        private System.Windows.Forms.GroupBox widget_Sensor3;
        private System.Windows.Forms.Label widget_Sensor3_Value;
        private System.Windows.Forms.GroupBox widget_Sensor2;
        private System.Windows.Forms.Label widget_Sensor2_Value;
        private System.Windows.Forms.ComboBox widget_Sensor1_Selector;
        private System.Windows.Forms.ComboBox widget_Sensor4_Selector;
        private System.Windows.Forms.ComboBox widget_Sensor3_Selector;
        private System.Windows.Forms.ComboBox widget_Sensor2_Selector;
        private System.Windows.Forms.GroupBox group_Temperature_Widgets;
        private Cyotek.Windows.Forms.RgbaColorSlider greenSlider;
        private Cyotek.Windows.Forms.RgbaColorSlider blueSlider;
        private Cyotek.Windows.Forms.RgbaColorSlider redSlider;
        private Cyotek.Windows.Forms.ColorGrid colorPalette;
        private System.Windows.Forms.Panel pan_ColorSample;
        private System.Windows.Forms.Button but_RGBPower;
        private System.Windows.Forms.ComboBox sel_RGBMode;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Timer colorTimer;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Label iter;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label timeCounter;
    }
}

