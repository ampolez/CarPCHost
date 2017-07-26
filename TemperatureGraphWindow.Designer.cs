namespace MultiControlHost
{
    partial class TemperatureGraphWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.LegendItem legendItem1 = new System.Windows.Forms.DataVisualization.Charting.LegendItem();
            System.Windows.Forms.DataVisualization.Charting.LegendCell legendCell1 = new System.Windows.Forms.DataVisualization.Charting.LegendCell();
            System.Windows.Forms.DataVisualization.Charting.LegendCell legendCell2 = new System.Windows.Forms.DataVisualization.Charting.LegendCell();
            this.temperature_chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.date_StartPeriod = new System.Windows.Forms.DateTimePicker();
            this.sel_SensorsToPlot = new System.Windows.Forms.CheckedListBox();
            this.group_Filter = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.val_MaxPointsNumber = new System.Windows.Forms.NumericUpDown();
            this.flag_RemovePeaks = new System.Windows.Forms.CheckBox();
            this.val_MaxDelta = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.btn_FilterQuery = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.date_EndPeriod = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_ShowHideFilter = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.group_GridSettings = new System.Windows.Forms.GroupBox();
            this.button13 = new System.Windows.Forms.Button();
            this.button12 = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.btn_SetGrids = new System.Windows.Forms.Button();
            this.set_MinorTickInterval = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.set_MinorTickType = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.set_MinorGridInterval = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.set_MinorGridType = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.set_MajorTickInterval = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.set_MajorTickType = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.set_MajorGridInterval = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.set_MajorGridType = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.group_Statistics = new System.Windows.Forms.GroupBox();
            this.button14 = new System.Windows.Forms.Button();
            this.lab_AvgTemp = new System.Windows.Forms.Label();
            this.lab_MaxTemp = new System.Windows.Forms.Label();
            this.lab_MinTemp = new System.Windows.Forms.Label();
            this.sel_SensorsSats = new System.Windows.Forms.ListBox();
            this.lab_PeaksRemoved = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.lab_PointsNumber = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.lab_EndPeriod = new System.Windows.Forms.Label();
            this.lab_StartPeriod = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.temperature_chart)).BeginInit();
            this.group_Filter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.val_MaxPointsNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.val_MaxDelta)).BeginInit();
            this.group_GridSettings.SuspendLayout();
            this.group_Statistics.SuspendLayout();
            this.SuspendLayout();
            // 
            // temperature_chart
            // 
            this.temperature_chart.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.temperature_chart.BorderSkin.BackColor = System.Drawing.Color.Transparent;
            this.temperature_chart.BorderSkin.BorderColor = System.Drawing.Color.Transparent;
            this.temperature_chart.BorderSkin.PageColor = System.Drawing.Color.Transparent;
            chartArea1.AxisX.Enabled = System.Windows.Forms.DataVisualization.Charting.AxisEnabled.True;
            chartArea1.AxisX.IntervalAutoMode = System.Windows.Forms.DataVisualization.Charting.IntervalAutoMode.VariableCount;
            chartArea1.AxisX.IsStartedFromZero = false;
            chartArea1.AxisX.LabelStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            chartArea1.AxisX.LabelStyle.Format = "hh:mm";
            chartArea1.AxisX.LabelStyle.Interval = 0D;
            chartArea1.AxisX.LabelStyle.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Auto;
            chartArea1.AxisX.MajorGrid.Interval = 1D;
            chartArea1.AxisX.MajorGrid.IntervalOffset = 0D;
            chartArea1.AxisX.MajorGrid.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Days;
            chartArea1.AxisX.MajorGrid.LineColor = System.Drawing.Color.DimGray;
            chartArea1.AxisX.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash;
            chartArea1.AxisX.MajorTickMark.Interval = 12D;
            chartArea1.AxisX.MajorTickMark.IntervalOffset = 0D;
            chartArea1.AxisX.MajorTickMark.IntervalOffsetType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Hours;
            chartArea1.AxisX.MajorTickMark.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Hours;
            chartArea1.AxisX.MajorTickMark.LineColor = System.Drawing.Color.Red;
            chartArea1.AxisX.MajorTickMark.LineWidth = 2;
            chartArea1.AxisX.MaximumAutoSize = 40F;
            chartArea1.AxisX.MinorGrid.Enabled = true;
            chartArea1.AxisX.MinorGrid.Interval = 1D;
            chartArea1.AxisX.MinorGrid.IntervalOffset = double.NaN;
            chartArea1.AxisX.MinorGrid.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Hours;
            chartArea1.AxisX.MinorGrid.LineColor = System.Drawing.Color.Gainsboro;
            chartArea1.AxisX.MinorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dot;
            chartArea1.AxisX.MinorTickMark.Enabled = true;
            chartArea1.AxisX.MinorTickMark.Interval = 1D;
            chartArea1.AxisX.MinorTickMark.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Hours;
            chartArea1.AxisX.MinorTickMark.LineColor = System.Drawing.Color.ForestGreen;
            chartArea1.AxisX.MinorTickMark.TickMarkStyle = System.Windows.Forms.DataVisualization.Charting.TickMarkStyle.AcrossAxis;
            chartArea1.AxisX.ScaleBreakStyle.Enabled = true;
            chartArea1.AxisX.ScaleBreakStyle.LineColor = System.Drawing.Color.Aqua;
            chartArea1.AxisX.ScaleBreakStyle.LineWidth = 2;
            chartArea1.AxisX.ScaleBreakStyle.MaxNumberOfBreaks = 5;
            chartArea1.AxisX.ScaleView.SmallScrollMinSize = 10D;
            chartArea1.AxisX.ScaleView.SmallScrollMinSizeType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Seconds;
            chartArea1.AxisX.ScaleView.SmallScrollSizeType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Days;
            chartArea1.AxisX.ScrollBar.Size = 20D;
            chartArea1.AxisX.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            chartArea1.AxisX2.IsMarginVisible = false;
            chartArea1.AxisX2.MajorGrid.Interval = 7D;
            chartArea1.AxisX2.MajorGrid.IntervalOffset = 0D;
            chartArea1.AxisX2.MajorGrid.IntervalOffsetType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Days;
            chartArea1.AxisX2.MajorGrid.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Days;
            chartArea1.AxisX2.MajorGrid.LineColor = System.Drawing.Color.OrangeRed;
            chartArea1.AxisX2.MajorTickMark.Interval = 1D;
            chartArea1.AxisX2.MajorTickMark.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Days;
            chartArea1.AxisX2.MaximumAutoSize = 90F;
            chartArea1.AxisX2.MinorGrid.Enabled = true;
            chartArea1.AxisX2.MinorGrid.Interval = 1D;
            chartArea1.AxisX2.MinorGrid.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Days;
            chartArea1.AxisX2.MinorGrid.LineColor = System.Drawing.Color.Chartreuse;
            chartArea1.AxisX2.MinorTickMark.Enabled = true;
            chartArea1.AxisX2.MinorTickMark.Interval = 12D;
            chartArea1.AxisX2.MinorTickMark.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Hours;
            chartArea1.AxisY.Interval = 1D;
            chartArea1.AxisY.IsStartedFromZero = false;
            chartArea1.AxisY.LabelStyle.Format = "0";
            chartArea1.AxisY.MajorGrid.Interval = 0D;
            chartArea1.AxisY.MajorGrid.IntervalOffset = 0D;
            chartArea1.AxisY.MajorGrid.LineColor = System.Drawing.Color.DimGray;
            chartArea1.AxisY.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash;
            chartArea1.AxisY.MaximumAutoSize = 95F;
            chartArea1.AxisY.MinorGrid.Enabled = true;
            chartArea1.AxisY.MinorGrid.LineColor = System.Drawing.Color.Gainsboro;
            chartArea1.AxisY.MinorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dot;
            chartArea1.AxisY2.Enabled = System.Windows.Forms.DataVisualization.Charting.AxisEnabled.False;
            chartArea1.AxisY2.MaximumAutoSize = 95F;
            chartArea1.BorderColor = System.Drawing.Color.DimGray;
            chartArea1.CursorX.Interval = 10D;
            chartArea1.CursorX.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Seconds;
            chartArea1.CursorX.IsUserEnabled = true;
            chartArea1.CursorX.IsUserSelectionEnabled = true;
            chartArea1.CursorX.LineWidth = 2;
            chartArea1.Name = "tempSensorPlotting";
            chartArea1.Position.Auto = false;
            chartArea1.Position.Height = 92F;
            chartArea1.Position.Width = 98F;
            chartArea1.Position.Y = 1F;
            this.temperature_chart.ChartAreas.Add(chartArea1);
            this.temperature_chart.Dock = System.Windows.Forms.DockStyle.Bottom;
            legend1.Alignment = System.Drawing.StringAlignment.Far;
            legendCell1.CellType = System.Windows.Forms.DataVisualization.Charting.LegendCellType.SeriesSymbol;
            legendCell1.Name = "Cell1";
            legendCell1.Text = "New";
            legendCell2.CellType = System.Windows.Forms.DataVisualization.Charting.LegendCellType.SeriesSymbol;
            legendCell2.Name = "Cell2";
            legendCell2.Text = "324";
            legendItem1.Cells.Add(legendCell1);
            legendItem1.Cells.Add(legendCell2);
            legendItem1.ImageStyle = System.Windows.Forms.DataVisualization.Charting.LegendImageStyle.Line;
            legendItem1.MarkerBorderWidth = 3;
            legendItem1.Name = "2134";
            legend1.CustomItems.Add(legendItem1);
            legend1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            legend1.IsTextAutoFit = false;
            legend1.ItemColumnSpacing = 10;
            legend1.LegendStyle = System.Windows.Forms.DataVisualization.Charting.LegendStyle.Row;
            legend1.MaximumAutoSize = 100F;
            legend1.Name = "SensorNames";
            legend1.Position.Auto = false;
            legend1.Position.Height = 6F;
            legend1.Position.Width = 100F;
            legend1.Position.Y = 93F;
            legend1.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.temperature_chart.Legends.Add(legend1);
            this.temperature_chart.Location = new System.Drawing.Point(0, 63);
            this.temperature_chart.Name = "temperature_chart";
            this.temperature_chart.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Pastel;
            this.temperature_chart.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.temperature_chart.Size = new System.Drawing.Size(784, 499);
            this.temperature_chart.TabIndex = 4;
            this.temperature_chart.Text = "chart1";
            this.temperature_chart.AxisViewChanged += new System.EventHandler<System.Windows.Forms.DataVisualization.Charting.ViewEventArgs>(this.temperature_chart_AxisViewChanged);
            // 
            // date_StartPeriod
            // 
            this.date_StartPeriod.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.date_StartPeriod.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.date_StartPeriod.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.date_StartPeriod.Location = new System.Drawing.Point(25, 64);
            this.date_StartPeriod.Name = "date_StartPeriod";
            this.date_StartPeriod.Size = new System.Drawing.Size(163, 31);
            this.date_StartPeriod.TabIndex = 5;
            // 
            // sel_SensorsToPlot
            // 
            this.sel_SensorsToPlot.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.sel_SensorsToPlot.FormattingEnabled = true;
            this.sel_SensorsToPlot.Location = new System.Drawing.Point(407, 64);
            this.sel_SensorsToPlot.Name = "sel_SensorsToPlot";
            this.sel_SensorsToPlot.Size = new System.Drawing.Size(355, 214);
            this.sel_SensorsToPlot.TabIndex = 6;
            // 
            // group_Filter
            // 
            this.group_Filter.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.group_Filter.Controls.Add(this.label5);
            this.group_Filter.Controls.Add(this.label4);
            this.group_Filter.Controls.Add(this.val_MaxPointsNumber);
            this.group_Filter.Controls.Add(this.flag_RemovePeaks);
            this.group_Filter.Controls.Add(this.val_MaxDelta);
            this.group_Filter.Controls.Add(this.label3);
            this.group_Filter.Controls.Add(this.btn_Cancel);
            this.group_Filter.Controls.Add(this.btn_FilterQuery);
            this.group_Filter.Controls.Add(this.label2);
            this.group_Filter.Controls.Add(this.date_EndPeriod);
            this.group_Filter.Controls.Add(this.label1);
            this.group_Filter.Controls.Add(this.sel_SensorsToPlot);
            this.group_Filter.Controls.Add(this.date_StartPeriod);
            this.group_Filter.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.group_Filter.Location = new System.Drawing.Point(0, 63);
            this.group_Filter.Name = "group_Filter";
            this.group_Filter.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.group_Filter.Size = new System.Drawing.Size(784, 302);
            this.group_Filter.TabIndex = 7;
            this.group_Filter.TabStop = false;
            this.group_Filter.Text = "Выборка температурных данных";
            this.group_Filter.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(22, 191);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(283, 16);
            this.label5.TabIndex = 18;
            this.label5.Text = "Максимальное число точек выборки:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(22, 150);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(255, 16);
            this.label4.TabIndex = 16;
            this.label4.Text = "Мак. отклонение от среднего, ºС:";
            // 
            // val_MaxPointsNumber
            // 
            this.val_MaxPointsNumber.Location = new System.Drawing.Point(313, 183);
            this.val_MaxPointsNumber.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.val_MaxPointsNumber.Name = "val_MaxPointsNumber";
            this.val_MaxPointsNumber.Size = new System.Drawing.Size(74, 29);
            this.val_MaxPointsNumber.TabIndex = 17;
            this.val_MaxPointsNumber.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // flag_RemovePeaks
            // 
            this.flag_RemovePeaks.AutoSize = true;
            this.flag_RemovePeaks.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.flag_RemovePeaks.Location = new System.Drawing.Point(25, 111);
            this.flag_RemovePeaks.Name = "flag_RemovePeaks";
            this.flag_RemovePeaks.Size = new System.Drawing.Size(298, 20);
            this.flag_RemovePeaks.TabIndex = 15;
            this.flag_RemovePeaks.Text = "Сглаживать экстремумы на графике";
            this.flag_RemovePeaks.UseVisualStyleBackColor = true;
            // 
            // val_MaxDelta
            // 
            this.val_MaxDelta.Location = new System.Drawing.Point(313, 142);
            this.val_MaxDelta.Name = "val_MaxDelta";
            this.val_MaxDelta.Size = new System.Drawing.Size(74, 29);
            this.val_MaxDelta.TabIndex = 14;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(404, 39);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 16);
            this.label3.TabIndex = 12;
            this.label3.Text = "Датчики:";
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Location = new System.Drawing.Point(224, 233);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(163, 45);
            this.btn_Cancel.TabIndex = 11;
            this.btn_Cancel.Text = "Скрыть";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // btn_FilterQuery
            // 
            this.btn_FilterQuery.Location = new System.Drawing.Point(25, 233);
            this.btn_FilterQuery.Name = "btn_FilterQuery";
            this.btn_FilterQuery.Size = new System.Drawing.Size(163, 45);
            this.btn_FilterQuery.TabIndex = 10;
            this.btn_FilterQuery.Text = "Выбрать";
            this.btn_FilterQuery.UseVisualStyleBackColor = true;
            this.btn_FilterQuery.Click += new System.EventHandler(this.btn_FilterQuery_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(221, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(161, 16);
            this.label2.TabIndex = 9;
            this.label2.Text = "Окончание периода:";
            // 
            // date_EndPeriod
            // 
            this.date_EndPeriod.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.date_EndPeriod.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.date_EndPeriod.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.date_EndPeriod.Location = new System.Drawing.Point(224, 64);
            this.date_EndPeriod.Name = "date_EndPeriod";
            this.date_EndPeriod.Size = new System.Drawing.Size(163, 31);
            this.date_EndPeriod.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(22, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(135, 16);
            this.label1.TabIndex = 7;
            this.label1.Text = "Начало периода:";
            // 
            // btn_ShowHideFilter
            // 
            this.btn_ShowHideFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_ShowHideFilter.Location = new System.Drawing.Point(12, 12);
            this.btn_ShowHideFilter.Name = "btn_ShowHideFilter";
            this.btn_ShowHideFilter.Size = new System.Drawing.Size(225, 44);
            this.btn_ShowHideFilter.TabIndex = 11;
            this.btn_ShowHideFilter.Text = "Настройка фильтра";
            this.btn_ShowHideFilter.UseVisualStyleBackColor = true;
            this.btn_ShowHideFilter.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.Location = new System.Drawing.Point(263, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(225, 44);
            this.button1.TabIndex = 12;
            this.button1.Text = "Настройка сетки";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button2.Location = new System.Drawing.Point(512, 12);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(260, 44);
            this.button2.TabIndex = 13;
            this.button2.Text = "Статистика по выборке";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // group_GridSettings
            // 
            this.group_GridSettings.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.group_GridSettings.Controls.Add(this.button13);
            this.group_GridSettings.Controls.Add(this.button12);
            this.group_GridSettings.Controls.Add(this.button11);
            this.group_GridSettings.Controls.Add(this.button10);
            this.group_GridSettings.Controls.Add(this.button9);
            this.group_GridSettings.Controls.Add(this.button8);
            this.group_GridSettings.Controls.Add(this.button7);
            this.group_GridSettings.Controls.Add(this.button6);
            this.group_GridSettings.Controls.Add(this.button5);
            this.group_GridSettings.Controls.Add(this.button3);
            this.group_GridSettings.Controls.Add(this.button4);
            this.group_GridSettings.Controls.Add(this.btn_SetGrids);
            this.group_GridSettings.Controls.Add(this.set_MinorTickInterval);
            this.group_GridSettings.Controls.Add(this.label10);
            this.group_GridSettings.Controls.Add(this.set_MinorTickType);
            this.group_GridSettings.Controls.Add(this.label11);
            this.group_GridSettings.Controls.Add(this.set_MinorGridInterval);
            this.group_GridSettings.Controls.Add(this.label12);
            this.group_GridSettings.Controls.Add(this.set_MinorGridType);
            this.group_GridSettings.Controls.Add(this.label13);
            this.group_GridSettings.Controls.Add(this.set_MajorTickInterval);
            this.group_GridSettings.Controls.Add(this.label8);
            this.group_GridSettings.Controls.Add(this.set_MajorTickType);
            this.group_GridSettings.Controls.Add(this.label9);
            this.group_GridSettings.Controls.Add(this.set_MajorGridInterval);
            this.group_GridSettings.Controls.Add(this.label7);
            this.group_GridSettings.Controls.Add(this.set_MajorGridType);
            this.group_GridSettings.Controls.Add(this.label6);
            this.group_GridSettings.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.group_GridSettings.Location = new System.Drawing.Point(0, 63);
            this.group_GridSettings.Name = "group_GridSettings";
            this.group_GridSettings.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.group_GridSettings.Size = new System.Drawing.Size(784, 278);
            this.group_GridSettings.TabIndex = 19;
            this.group_GridSettings.TabStop = false;
            this.group_GridSettings.Text = "Настройка сетки графика";
            this.group_GridSettings.Visible = false;
            // 
            // button13
            // 
            this.button13.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button13.Location = new System.Drawing.Point(714, 200);
            this.button13.Name = "button13";
            this.button13.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.button13.Size = new System.Drawing.Size(60, 60);
            this.button13.TabIndex = 47;
            this.button13.Text = "X";
            this.button13.UseVisualStyleBackColor = true;
            // 
            // button12
            // 
            this.button12.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button12.Location = new System.Drawing.Point(604, 200);
            this.button12.Name = "button12";
            this.button12.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.button12.Size = new System.Drawing.Size(60, 60);
            this.button12.TabIndex = 46;
            this.button12.Text = "9";
            this.button12.UseVisualStyleBackColor = true;
            this.button12.Click += new System.EventHandler(this.button12_Click);
            // 
            // button11
            // 
            this.button11.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button11.Location = new System.Drawing.Point(538, 200);
            this.button11.Name = "button11";
            this.button11.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.button11.Size = new System.Drawing.Size(60, 60);
            this.button11.TabIndex = 45;
            this.button11.Text = "8";
            this.button11.UseVisualStyleBackColor = true;
            this.button11.Click += new System.EventHandler(this.button11_Click);
            // 
            // button10
            // 
            this.button10.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button10.Location = new System.Drawing.Point(472, 200);
            this.button10.Name = "button10";
            this.button10.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.button10.Size = new System.Drawing.Size(60, 60);
            this.button10.TabIndex = 44;
            this.button10.Text = "7";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // button9
            // 
            this.button9.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button9.Location = new System.Drawing.Point(406, 200);
            this.button9.Name = "button9";
            this.button9.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.button9.Size = new System.Drawing.Size(60, 60);
            this.button9.TabIndex = 43;
            this.button9.Text = "6";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // button8
            // 
            this.button8.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button8.Location = new System.Drawing.Point(340, 200);
            this.button8.Name = "button8";
            this.button8.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.button8.Size = new System.Drawing.Size(60, 60);
            this.button8.TabIndex = 42;
            this.button8.Text = "5";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // button7
            // 
            this.button7.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button7.Location = new System.Drawing.Point(274, 200);
            this.button7.Name = "button7";
            this.button7.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.button7.Size = new System.Drawing.Size(60, 60);
            this.button7.TabIndex = 41;
            this.button7.Text = "4";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button6
            // 
            this.button6.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button6.Location = new System.Drawing.Point(208, 200);
            this.button6.Name = "button6";
            this.button6.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.button6.Size = new System.Drawing.Size(60, 60);
            this.button6.TabIndex = 40;
            this.button6.Text = "3";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button5
            // 
            this.button5.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button5.Location = new System.Drawing.Point(142, 200);
            this.button5.Name = "button5";
            this.button5.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.button5.Size = new System.Drawing.Size(60, 60);
            this.button5.TabIndex = 39;
            this.button5.Text = "2";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button3.Location = new System.Drawing.Point(76, 200);
            this.button3.Name = "button3";
            this.button3.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.button3.Size = new System.Drawing.Size(60, 60);
            this.button3.TabIndex = 38;
            this.button3.Text = "1";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button4.Location = new System.Drawing.Point(10, 200);
            this.button4.Name = "button4";
            this.button4.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.button4.Size = new System.Drawing.Size(60, 60);
            this.button4.TabIndex = 37;
            this.button4.Text = "0";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // btn_SetGrids
            // 
            this.btn_SetGrids.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_SetGrids.Location = new System.Drawing.Point(648, 39);
            this.btn_SetGrids.Name = "btn_SetGrids";
            this.btn_SetGrids.Size = new System.Drawing.Size(126, 143);
            this.btn_SetGrids.TabIndex = 35;
            this.btn_SetGrids.Text = "OK";
            this.btn_SetGrids.UseVisualStyleBackColor = true;
            this.btn_SetGrids.Click += new System.EventHandler(this.btn_SetGrids_Click);
            // 
            // set_MinorTickInterval
            // 
            this.set_MinorTickInterval.Location = new System.Drawing.Point(576, 153);
            this.set_MinorTickInterval.Name = "set_MinorTickInterval";
            this.set_MinorTickInterval.Size = new System.Drawing.Size(63, 29);
            this.set_MinorTickInterval.TabIndex = 34;
            this.set_MinorTickInterval.Leave += new System.EventHandler(this.set_MajorGridInterval_Leave);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label10.Location = new System.Drawing.Point(363, 161);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(171, 16);
            this.label10.TabIndex = 33;
            this.label10.Text = "Доп. метка, интервал:";
            // 
            // set_MinorTickType
            // 
            this.set_MinorTickType.FormattingEnabled = true;
            this.set_MinorTickType.Location = new System.Drawing.Point(215, 156);
            this.set_MinorTickType.Name = "set_MinorTickType";
            this.set_MinorTickType.Size = new System.Drawing.Size(135, 32);
            this.set_MinorTickType.TabIndex = 32;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label11.Location = new System.Drawing.Point(8, 161);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(164, 16);
            this.label11.TabIndex = 31;
            this.label11.Text = "Доп. метка, единицы:";
            // 
            // set_MinorGridInterval
            // 
            this.set_MinorGridInterval.Location = new System.Drawing.Point(576, 118);
            this.set_MinorGridInterval.Name = "set_MinorGridInterval";
            this.set_MinorGridInterval.Size = new System.Drawing.Size(63, 29);
            this.set_MinorGridInterval.TabIndex = 30;
            this.set_MinorGridInterval.Leave += new System.EventHandler(this.set_MajorGridInterval_Leave);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label12.Location = new System.Drawing.Point(363, 123);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(169, 16);
            this.label12.TabIndex = 29;
            this.label12.Text = "Доп. стека, интервал:";
            // 
            // set_MinorGridType
            // 
            this.set_MinorGridType.FormattingEnabled = true;
            this.set_MinorGridType.Location = new System.Drawing.Point(215, 115);
            this.set_MinorGridType.Name = "set_MinorGridType";
            this.set_MinorGridType.Size = new System.Drawing.Size(135, 32);
            this.set_MinorGridType.TabIndex = 28;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label13.Location = new System.Drawing.Point(8, 123);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(162, 16);
            this.label13.TabIndex = 27;
            this.label13.Text = "Доп. сетка, единицы:";
            // 
            // set_MajorTickInterval
            // 
            this.set_MajorTickInterval.Location = new System.Drawing.Point(576, 80);
            this.set_MajorTickInterval.Name = "set_MajorTickInterval";
            this.set_MajorTickInterval.Size = new System.Drawing.Size(63, 29);
            this.set_MajorTickInterval.TabIndex = 26;
            this.set_MajorTickInterval.Leave += new System.EventHandler(this.set_MajorGridInterval_Leave);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.Location = new System.Drawing.Point(363, 85);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(211, 16);
            this.label8.TabIndex = 25;
            this.label8.Text = "Основная метка, интервал:";
            // 
            // set_MajorTickType
            // 
            this.set_MajorTickType.FormattingEnabled = true;
            this.set_MajorTickType.Location = new System.Drawing.Point(215, 77);
            this.set_MajorTickType.Name = "set_MajorTickType";
            this.set_MajorTickType.Size = new System.Drawing.Size(135, 32);
            this.set_MajorTickType.TabIndex = 24;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label9.Location = new System.Drawing.Point(8, 85);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(204, 16);
            this.label9.TabIndex = 23;
            this.label9.Text = "Основная метка, единицы:";
            // 
            // set_MajorGridInterval
            // 
            this.set_MajorGridInterval.Location = new System.Drawing.Point(576, 42);
            this.set_MajorGridInterval.Name = "set_MajorGridInterval";
            this.set_MajorGridInterval.Size = new System.Drawing.Size(63, 29);
            this.set_MajorGridInterval.TabIndex = 22;
            this.set_MajorGridInterval.Leave += new System.EventHandler(this.set_MajorGridInterval_Leave);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(363, 47);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(209, 16);
            this.label7.TabIndex = 21;
            this.label7.Text = "Основная сетка, интервал:";
            // 
            // set_MajorGridType
            // 
            this.set_MajorGridType.FormattingEnabled = true;
            this.set_MajorGridType.Location = new System.Drawing.Point(215, 39);
            this.set_MajorGridType.Name = "set_MajorGridType";
            this.set_MajorGridType.Size = new System.Drawing.Size(135, 32);
            this.set_MajorGridType.TabIndex = 20;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(8, 47);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(202, 16);
            this.label6.TabIndex = 19;
            this.label6.Text = "Основная сетка, единицы:";
            // 
            // group_Statistics
            // 
            this.group_Statistics.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.group_Statistics.Controls.Add(this.button14);
            this.group_Statistics.Controls.Add(this.lab_AvgTemp);
            this.group_Statistics.Controls.Add(this.lab_MaxTemp);
            this.group_Statistics.Controls.Add(this.lab_MinTemp);
            this.group_Statistics.Controls.Add(this.sel_SensorsSats);
            this.group_Statistics.Controls.Add(this.lab_PeaksRemoved);
            this.group_Statistics.Controls.Add(this.label23);
            this.group_Statistics.Controls.Add(this.lab_PointsNumber);
            this.group_Statistics.Controls.Add(this.label21);
            this.group_Statistics.Controls.Add(this.lab_EndPeriod);
            this.group_Statistics.Controls.Add(this.lab_StartPeriod);
            this.group_Statistics.Controls.Add(this.label18);
            this.group_Statistics.Controls.Add(this.label17);
            this.group_Statistics.Controls.Add(this.label16);
            this.group_Statistics.Controls.Add(this.label15);
            this.group_Statistics.Controls.Add(this.label14);
            this.group_Statistics.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.group_Statistics.Location = new System.Drawing.Point(0, 63);
            this.group_Statistics.Name = "group_Statistics";
            this.group_Statistics.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.group_Statistics.Size = new System.Drawing.Size(784, 199);
            this.group_Statistics.TabIndex = 48;
            this.group_Statistics.TabStop = false;
            this.group_Statistics.Text = "Статистика по выборке";
            this.group_Statistics.Visible = false;
            // 
            // button14
            // 
            this.button14.Location = new System.Drawing.Point(589, 73);
            this.button14.Name = "button14";
            this.button14.Size = new System.Drawing.Size(165, 98);
            this.button14.TabIndex = 37;
            this.button14.Text = "Закрыть";
            this.button14.UseVisualStyleBackColor = true;
            this.button14.Click += new System.EventHandler(this.button14_Click);
            // 
            // lab_AvgTemp
            // 
            this.lab_AvgTemp.AutoSize = true;
            this.lab_AvgTemp.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lab_AvgTemp.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lab_AvgTemp.Location = new System.Drawing.Point(478, 150);
            this.lab_AvgTemp.Name = "lab_AvgTemp";
            this.lab_AvgTemp.Size = new System.Drawing.Size(96, 25);
            this.lab_AvgTemp.TabIndex = 35;
            this.lab_AvgTemp.Text = "1000 ºС";
            // 
            // lab_MaxTemp
            // 
            this.lab_MaxTemp.AutoSize = true;
            this.lab_MaxTemp.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lab_MaxTemp.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lab_MaxTemp.Location = new System.Drawing.Point(478, 114);
            this.lab_MaxTemp.Name = "lab_MaxTemp";
            this.lab_MaxTemp.Size = new System.Drawing.Size(96, 25);
            this.lab_MaxTemp.TabIndex = 34;
            this.lab_MaxTemp.Text = "1000 ºС";
            // 
            // lab_MinTemp
            // 
            this.lab_MinTemp.AutoSize = true;
            this.lab_MinTemp.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lab_MinTemp.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lab_MinTemp.Location = new System.Drawing.Point(478, 76);
            this.lab_MinTemp.Name = "lab_MinTemp";
            this.lab_MinTemp.Size = new System.Drawing.Size(96, 25);
            this.lab_MinTemp.TabIndex = 33;
            this.lab_MinTemp.Text = "1000 ºС";
            // 
            // sel_SensorsSats
            // 
            this.sel_SensorsSats.FormattingEnabled = true;
            this.sel_SensorsSats.ItemHeight = 24;
            this.sel_SensorsSats.Location = new System.Drawing.Point(14, 72);
            this.sel_SensorsSats.Name = "sel_SensorsSats";
            this.sel_SensorsSats.Size = new System.Drawing.Size(213, 100);
            this.sel_SensorsSats.TabIndex = 31;
            this.sel_SensorsSats.SelectedIndexChanged += new System.EventHandler(this.sel_SensorsSats_SelectedIndexChanged);
            // 
            // lab_PeaksRemoved
            // 
            this.lab_PeaksRemoved.AutoSize = true;
            this.lab_PeaksRemoved.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lab_PeaksRemoved.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lab_PeaksRemoved.Location = new System.Drawing.Point(657, 38);
            this.lab_PeaksRemoved.Name = "lab_PeaksRemoved";
            this.lab_PeaksRemoved.Size = new System.Drawing.Size(97, 16);
            this.lab_PeaksRemoved.TabIndex = 30;
            this.lab_PeaksRemoved.Text = "Да, Δ = 10 ºС";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label23.Location = new System.Drawing.Point(547, 38);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(111, 16);
            this.label23.TabIndex = 29;
            this.label23.Text = "Сглаживание:";
            // 
            // lab_PointsNumber
            // 
            this.lab_PointsNumber.AutoSize = true;
            this.lab_PointsNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lab_PointsNumber.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lab_PointsNumber.Location = new System.Drawing.Point(492, 38);
            this.lab_PointsNumber.Name = "lab_PointsNumber";
            this.lab_PointsNumber.Size = new System.Drawing.Size(40, 16);
            this.lab_PointsNumber.TabIndex = 28;
            this.lab_PointsNumber.Text = "1000";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label21.Location = new System.Drawing.Point(346, 38);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(147, 16);
            this.label21.TabIndex = 27;
            this.label21.Text = "Количество точек:";
            // 
            // lab_EndPeriod
            // 
            this.lab_EndPeriod.AutoSize = true;
            this.lab_EndPeriod.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lab_EndPeriod.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lab_EndPeriod.Location = new System.Drawing.Point(237, 38);
            this.lab_EndPeriod.Name = "lab_EndPeriod";
            this.lab_EndPeriod.Size = new System.Drawing.Size(80, 16);
            this.lab_EndPeriod.TabIndex = 26;
            this.lab_EndPeriod.Text = "15.05.2015";
            // 
            // lab_StartPeriod
            // 
            this.lab_StartPeriod.AutoSize = true;
            this.lab_StartPeriod.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lab_StartPeriod.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lab_StartPeriod.Location = new System.Drawing.Point(117, 38);
            this.lab_StartPeriod.Name = "lab_StartPeriod";
            this.lab_StartPeriod.Size = new System.Drawing.Size(80, 16);
            this.lab_StartPeriod.TabIndex = 25;
            this.lab_StartPeriod.Text = "12.05.2015";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label18.Location = new System.Drawing.Point(244, 150);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(176, 16);
            this.label18.TabIndex = 24;
            this.label18.Text = "Средняя температура:";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label17.Location = new System.Drawing.Point(244, 115);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(222, 16);
            this.label17.TabIndex = 23;
            this.label17.Text = "Максимальная температура:";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label16.Location = new System.Drawing.Point(244, 80);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(215, 16);
            this.label16.TabIndex = 22;
            this.label16.Text = "Минимальная температура:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label15.Location = new System.Drawing.Point(202, 38);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(30, 16);
            this.label15.TabIndex = 21;
            this.label15.Text = "по:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label14.Location = new System.Drawing.Point(12, 38);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(101, 16);
            this.label14.TabIndex = 20;
            this.label14.Text = "За период с:";
            // 
            // TemperatureGraphWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.group_Statistics);
            this.Controls.Add(this.group_GridSettings);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.group_Filter);
            this.Controls.Add(this.temperature_chart);
            this.Controls.Add(this.btn_ShowHideFilter);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "TemperatureGraphWindow";
            this.Text = "TemperatureGraphWindow";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TemperatureGraphWindow_FormClosing);
            this.Load += new System.EventHandler(this.TemperatureGraphWindow_Load);
            ((System.ComponentModel.ISupportInitialize)(this.temperature_chart)).EndInit();
            this.group_Filter.ResumeLayout(false);
            this.group_Filter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.val_MaxPointsNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.val_MaxDelta)).EndInit();
            this.group_GridSettings.ResumeLayout(false);
            this.group_GridSettings.PerformLayout();
            this.group_Statistics.ResumeLayout(false);
            this.group_Statistics.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart temperature_chart;
        private System.Windows.Forms.DateTimePicker date_StartPeriod;
        private System.Windows.Forms.CheckedListBox sel_SensorsToPlot;
        private System.Windows.Forms.GroupBox group_Filter;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker date_EndPeriod;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_FilterQuery;
        private System.Windows.Forms.Button btn_ShowHideFilter;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox flag_RemovePeaks;
        private System.Windows.Forms.NumericUpDown val_MaxDelta;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown val_MaxPointsNumber;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.GroupBox group_GridSettings;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox set_MinorTickInterval;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox set_MinorTickType;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox set_MinorGridInterval;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox set_MinorGridType;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox set_MajorTickInterval;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox set_MajorTickType;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox set_MajorGridInterval;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox set_MajorGridType;
        private System.Windows.Forms.Button btn_SetGrids;
        private System.Windows.Forms.Button button13;
        private System.Windows.Forms.Button button12;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.GroupBox group_Statistics;
        private System.Windows.Forms.Label lab_PeaksRemoved;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label lab_PointsNumber;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label lab_EndPeriod;
        private System.Windows.Forms.Label lab_StartPeriod;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ListBox sel_SensorsSats;
        private System.Windows.Forms.Label lab_AvgTemp;
        private System.Windows.Forms.Label lab_MaxTemp;
        private System.Windows.Forms.Label lab_MinTemp;
        private System.Windows.Forms.Button button14;
    }
}