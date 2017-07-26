using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PCComm;

namespace MultiControlHost
{
    public partial class TemperatureGraphWindow : Form
    {
        System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea = null;

        private IDictionary<int, SQLiteAdapter.SensorData> _sensorsDB = null;
        private IDictionary<int, SQLiteAdapter.TempStatistics> _sensorStats = new Dictionary<int, SQLiteAdapter.TempStatistics>();
        private SQLiteAdapter dbHandler = new SQLiteAdapter("temperature.db");
        private Control lastFocusedControl = null;


        public TemperatureGraphWindow()
        {
            InitializeComponent();
        }

        /*
         * Заполняет список датчиков температуры. 
         * Рисует графики температур с параметрами по-умолчанию
         */
        private void TemperatureGraphWindow_Load(object sender, EventArgs e)
        {
            this.dbHandler.Open();
            sel_SensorsToPlot.Items.Clear();
            this._sensorsDB = this.dbHandler.ListDBSensors();
            if (this._sensorsDB != null)
            {
                flag_RemovePeaks.Checked = true;
                val_MaxDelta.Value = 10;
                val_MaxPointsNumber.Value = 0;
                date_StartPeriod.Value = DateTime.Today.Date.AddDays(-1);
                date_EndPeriod.Value = DateTime.Today.Date.AddHours(23).AddMinutes(59).AddSeconds(59);

                /*
                 * Данные на панели статистики:
                 */
                lab_PeaksRemoved.Text = flag_RemovePeaks.Checked == true ? "Да, Δ = " + val_MaxDelta.Value.ToString() + " ºС" : "Нет";
                lab_PointsNumber.Text = val_MaxPointsNumber.Value.ToString();
                lab_StartPeriod.Text = date_StartPeriod.Value.ToString("dd.MM.yyy");
                lab_EndPeriod.Text = date_EndPeriod.Value.ToString("dd.MM.yyyy");

                foreach (var _sensor in this._sensorsDB)
                {
                    sel_SensorsToPlot.Items.Add(new PCComm.ComboboxItem (_sensor.Value.sensorName, _sensor.Key.ToString() ), true);
                    sel_SensorsSats.Items.Add(new PCComm.ComboboxItem(_sensor.Value.sensorName, _sensor.Key.ToString()));

                    // Аргументы для запроса SQLite
                    SQLiteAdapter.SQLiteQueryArgs dbArgs =
                        new SQLiteAdapter.SQLiteQueryArgs
                        {
                            sensorID = _sensor.Key,
                            startPeriod = DateTime.Today.Date.AddDays(-1),
                            endPeriod = DateTime.Today.Date.AddHours(23).AddMinutes(59).AddSeconds(59),
                            removePeaks = flag_RemovePeaks.Checked,
                            limit = Int32.Parse(val_MaxPointsNumber.Value.ToString()),
                            maxDelta = Int32.Parse(val_MaxDelta.Value.ToString())
                        };
                    drawSensorGraph(dbArgs);
                }
                if (sel_SensorsSats.Items.Count > 0)
                {
                    sel_SensorsSats.SelectedIndex = 0;
                }
            }

            /* 
             * Настройки сетки по-умолчанию
             */
            this.chartArea = temperature_chart.ChartAreas.First();
           
            // Единицы измерения сеток и меток
            foreach (var gridType in Enum.GetValues(typeof(System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType)))
            {
                set_MajorGridType.Items.Add(gridType);
                set_MajorTickType.Items.Add(gridType);
                set_MinorGridType.Items.Add(gridType);
                set_MinorTickType.Items.Add(gridType);
            }
            set_MajorGridType.SelectedItem = chartArea.AxisX.MajorGrid.IntervalType;
            set_MajorTickType.SelectedItem = chartArea.AxisX.MajorTickMark.IntervalType;
            set_MinorGridType.SelectedItem = chartArea.AxisX.MinorGrid.IntervalType;
            set_MinorTickType.SelectedItem = chartArea.AxisX.MinorTickMark.IntervalType;

            // Интервалы сеток и меток
            set_MajorGridInterval.Text = chartArea.AxisX.MajorGrid.Interval.ToString();
            set_MajorTickInterval.Text = chartArea.AxisX.MajorTickMark.Interval.ToString();
            set_MinorGridInterval.Text = chartArea.AxisX.MinorGrid.Interval.ToString();
            set_MinorTickInterval.Text = chartArea.AxisX.MinorTickMark.Interval.ToString();

        }

        /*
         * Создает область для графика температур датчика, настривает его внешний вид
         * Рисует график температур в соответствии с данными фильтра выборки dbArgs
         */
        private void drawSensorGraph(SQLiteAdapter.SQLiteQueryArgs dbArgs)
        {
            var _sensor = this._sensorsDB[dbArgs.sensorID];
            var temperaturePoints = dbHandler.QueryTempValues(dbArgs);
            TimeSpan datePeriod = dbArgs.endPeriod - dbArgs.startPeriod;
            
            this._sensorStats.Add(dbArgs.sensorID, temperaturePoints.stats);

            if (temperature_chart.Series.IndexOf(_sensor.sensorName) != -1)
            {
                Random rnd = new Random();
                _sensor.sensorName = _sensor.sensorROM;
            }

            temperature_chart.Series.Add(_sensor.sensorName);
            var chartArea = temperature_chart.ChartAreas.First();

            if (datePeriod.TotalHours <= 24)
            {
                chartArea.AxisX.LabelStyle.Format = "hh:mm:ss";
                chartArea.AxisX.LabelStyle.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Hours;
                chartArea.AxisX.LabelStyle.Interval = 1D;
            }
            else if (datePeriod.TotalHours > 24 && datePeriod.TotalDays <= 30)
            {
                chartArea.AxisX.LabelStyle.Format = "dd.MM.yy";
                chartArea.AxisX.LabelStyle.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Days;
                chartArea.AxisX.LabelStyle.Interval = 1D;
            }
            else
            {
                chartArea.AxisX.LabelStyle.Format = "dd.MM.yy";
                chartArea.AxisX.LabelStyle.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Days;
                chartArea.AxisX.LabelStyle.Interval = 1D;
            }
            temperature_chart.Series[_sensor.sensorName].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
            temperature_chart.Series[_sensor.sensorName].BorderWidth = 3;
            temperature_chart.Series[_sensor.sensorName].Points.DataBindXY(temperaturePoints.tValue.Keys, temperaturePoints.tValue.Values);
        }

        public void ChartZoom()
        {

            DateTime max = DateTime.FromOADate(temperature_chart.ChartAreas[0].AxisX.ScaleView.ViewMaximum);
            DateTime min = DateTime.FromOADate(temperature_chart.ChartAreas[0].AxisX.ScaleView.ViewMinimum);
            TimeSpan spanne = max - min;
            TimeSpan seconds = new TimeSpan(0, 5, 0);
            TimeSpan minutes = new TimeSpan(23, 0, 0);
            TimeSpan hours = new TimeSpan(96, 0, 0);
            TimeSpan days = new TimeSpan(240, 0, 0);


            if (spanne < seconds)
            {
                temperature_chart.ChartAreas[0].AxisX.LabelStyle.Format = "HH:mm:ss";
                temperature_chart.ChartAreas[0].AxisX.LabelStyle.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Minutes;
                temperature_chart.ChartAreas[0].AxisX.LabelStyle.Interval = 1D;

            }
            else if (spanne < minutes)
            {
                temperature_chart.ChartAreas[0].AxisX.LabelStyle.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Hours;
                temperature_chart.ChartAreas[0].AxisX.LabelStyle.Interval = 1D;
                temperature_chart.ChartAreas[0].AxisX.LabelStyle.Format = "HH:mm";
            }
            else if (spanne < hours)
            {
                temperature_chart.ChartAreas[0].AxisX.LabelStyle.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Days;
                temperature_chart.ChartAreas[0].AxisX.LabelStyle.Interval = 1D;
                temperature_chart.ChartAreas[0].AxisX.LabelStyle.Format = "dd:MM HH:mm";
            }
            else if (spanne < days)
            {
                temperature_chart.ChartAreas[0].AxisX.LabelStyle.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Days;
                temperature_chart.ChartAreas[0].AxisX.LabelStyle.Interval = 1D;
                temperature_chart.ChartAreas[0].AxisX.LabelStyle.Format = "dd:MM HH:mm";
            }
            else
            {
                temperature_chart.ChartAreas[0].AxisX.LabelStyle.Format = "dd:MM:yy";
            }

        }

        /*
         * Показать панель выбора фильтров для запроса
         */
        private void button2_Click(object sender, EventArgs e)
        {
            temperature_chart.Enabled = false;
            group_GridSettings.Hide();
            group_Statistics.Hide();
            group_Filter.Show();
        }

        /*
         * Собирает данные для формирования фильтрующих запросов к БД из форм пользователя
         * Получет данные из БД и рисует графики для выбранных датчиков
         */
        private void btn_FilterQuery_Click(object sender, EventArgs e)
        {
            if (sel_SensorsToPlot.CheckedItems.Count > 0)
            {
                int sql_limit = Int32.Parse(val_MaxPointsNumber.Value.ToString());
                int sql_maxDelta = Int32.Parse(val_MaxDelta.Value.ToString());
                bool sql_removePeaks = flag_RemovePeaks.Checked;

                if (sql_maxDelta <= 0)
                {
                    sql_removePeaks = false;
                }

                temperature_chart.Series.Clear();
                this._sensorStats.Clear();

                /*
                 * Данные на панели статистики:
                 */
                sel_SensorsSats.Items.Clear();
                lab_PeaksRemoved.Text = flag_RemovePeaks.Checked == true ? "Да, Δ = " + val_MaxDelta.Value.ToString() + " ºС" : "Нет";
                lab_PointsNumber.Text = val_MaxPointsNumber.Value.ToString();
                lab_StartPeriod.Text = date_StartPeriod.Value.ToString("dd.MM.yyy");
                lab_EndPeriod.Text = date_EndPeriod.Value.ToString("dd.MM.yyyy");

                foreach (PCComm.ComboboxItem sensorSelected in sel_SensorsToPlot.CheckedItems)
                {
                    sel_SensorsSats.Items.Add(new PCComm.ComboboxItem(sensorSelected.Text, sensorSelected.Value));

                    SQLiteAdapter.SQLiteQueryArgs dbArgs =
                        new SQLiteAdapter.SQLiteQueryArgs
                        {
                            sensorID = Int32.Parse(sensorSelected.Value),
                            startPeriod = date_StartPeriod.Value.Date,
                            endPeriod = date_EndPeriod.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59),
                            removePeaks = sql_removePeaks,
                            limit = sql_limit,
                            maxDelta = sql_maxDelta
                        };
                    drawSensorGraph(dbArgs);
                }
                if (sel_SensorsSats.Items.Count > 0)
                {
                    sel_SensorsSats.SelectedIndex = 0;
                }
            }
        }

        /*
         * Скрыть панель выбора фильтров для запроса
         */
        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            group_Filter.Hide();
            group_Statistics.Hide();
            temperature_chart.Enabled = true;
        }

        /*
         * Применяет настройки сетки графика, скрывает панель настроек
         */
        private void btn_SetGrids_Click(object sender, EventArgs e)
        {
            chartArea.AxisX.MajorGrid.IntervalType = (System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType)set_MajorGridType.SelectedItem;
            chartArea.AxisX.MajorTickMark.IntervalType = (System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType)set_MajorTickType.SelectedItem;
            chartArea.AxisX.MinorGrid.IntervalType = (System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType)set_MinorGridType.SelectedItem;
            chartArea.AxisX.MinorTickMark.IntervalType = (System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType)set_MinorTickType.SelectedItem;

            // Интервалы сеток и меток
            chartArea.AxisX.MajorGrid.Interval = set_MajorGridInterval.Text == "" ? 1 : Double.Parse(set_MajorGridInterval.Text);
            chartArea.AxisX.MajorTickMark.Interval = set_MajorTickInterval.Text == "" ? 1 : Double.Parse(set_MajorTickInterval.Text);
            chartArea.AxisX.MinorGrid.Interval = set_MinorGridInterval.Text == "" ? 1 : Double.Parse(set_MinorGridInterval.Text);
            chartArea.AxisX.MinorTickMark.Interval = set_MinorTickInterval.Text == "" ? 1 : Double.Parse(set_MinorTickInterval.Text);

            group_GridSettings.Hide();
            temperature_chart.Enabled = true;
        }

        /*
         * Показывает панель с настройками сетки графика
         */
        private void button1_Click(object sender, EventArgs e)
        {
            group_Filter.Hide();
            group_Statistics.Hide();
            group_GridSettings.Show();
            temperature_chart.Enabled = false;
        }

        /*
         * Присваеивает значение последнего выбранного элемента формы для "сенсорных" кнопок
         */
        private void set_MajorGridInterval_Leave(object sender, EventArgs e)
        {
            this.lastFocusedControl = (Control)sender;
            if (this.lastFocusedControl.Text == "")
            {
                this.lastFocusedControl.Text = "1";
            }
        }

        #region Сенсорные кнопки
        private void button4_Click(object sender, EventArgs e)
        {
            if (this.lastFocusedControl != null)
            {
                this.lastFocusedControl.Text += "0";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (this.lastFocusedControl != null)
            {
                this.lastFocusedControl.Text += "1";
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (this.lastFocusedControl != null)
            {
                this.lastFocusedControl.Text += "2";
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (this.lastFocusedControl != null)
            {
                this.lastFocusedControl.Text += "3";
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (this.lastFocusedControl != null)
            {
                this.lastFocusedControl.Text += "4";
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (this.lastFocusedControl != null)
            {
                this.lastFocusedControl.Text += "5";
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (this.lastFocusedControl != null)
            {
                this.lastFocusedControl.Text += "6";
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (this.lastFocusedControl != null)
            {
                this.lastFocusedControl.Text += "7";
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (this.lastFocusedControl != null)
            {
                this.lastFocusedControl.Text += "8";
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (this.lastFocusedControl != null)
            {
                this.lastFocusedControl.Text += "9";
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {

        }
        #endregion

        private void button2_Click_1(object sender, EventArgs e)
        {
            group_Filter.Hide();
            group_GridSettings.Hide();
            group_Statistics.Show();

        }

        private void button14_Click(object sender, EventArgs e)
        {
            group_Statistics.Hide();
            temperature_chart.Enabled = true;
        }

        private void sel_SensorsSats_SelectedIndexChanged(object sender, EventArgs e)
        {
            PCComm.ComboboxItem selectedSensor = (PCComm.ComboboxItem)sel_SensorsSats.SelectedItem;
            int selSensorID = Int32.Parse(selectedSensor.Value);
            lab_AvgTemp.Text = this._sensorStats[selSensorID].tAvg.ToString("0.0") + " ºС";
            lab_MaxTemp.Text = this._sensorStats[selSensorID].tMax.ToString("0.0") + " ºС";
            lab_MinTemp.Text = this._sensorStats[selSensorID].tMin.ToString("0.0") + " ºС";
        }

        private void TemperatureGraphWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.dbHandler.Close();
        }

        private void temperature_chart_AxisViewChanged(object sender, System.Windows.Forms.DataVisualization.Charting.ViewEventArgs e)
        {
            this.ChartZoom();
        }

    }
}
