using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Windows.Forms;

namespace MultiControlHost
{
    public class SQLiteAdapter
    {

        private string SQLiteFileName = string.Empty;   // Название файла с базой SQLite

        /*
         * Команды для создания новых таблиц
         */
        private string sql_CreateSensorsTable = "CREATE TABLE IF NOT EXISTS sensors (id INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL, rom varchar(8), name TEXT);";
        private string sql_CreateValuesTable = "CREATE TABLE IF NOT EXISTS temperatures (id INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL, sensorID INTEGER, temperature REAL, date DATETIME, FOREIGN KEY(sensorID) REFERENCES sensors(id));";

        /* 
         * Указатель SQLite
         */
        public SQLiteConnection dbConnection = null;

        /*
         * Структура, описывающая возможные аргументы в запросе SQLite
         */
        public struct SQLiteQueryArgs
        {
            public int sensorID;            // Внутренний id датчика
            public int maxDelta;            // максимально допустимое отклонение от среднего значения
            public int limit;               // максимальное число элементов в выборке
            public DateTime startPeriod;    // дата-время начала выборки
            public DateTime endPeriod;      // дата-время окончания выборки
            public bool removePeaks;        // флаг сглаживания экстремумов
        }

        public struct SensorData 
        {
            public string sensorROM;
            public string sensorName;
        }

        public struct TempStatistics
        {
            public float tMax;
            public float tMin;
            public float tAvg;
        }
        public struct QueryResult
        {
            public TempStatistics stats;
            public IDictionary<DateTime, double> tValue;
        }

        /*
         * Констурктор. Определяет название файла с базой SQLIte
         */
        public SQLiteAdapter(string dbFileName)
        {
            this.SQLiteFileName = dbFileName;
        }

        /*
         * Открывает файл с базой SQLite, если его нет - автоматически создает
         */
        public void Open()
        {
            try
            {
                this.dbConnection = new SQLiteConnection("Data Source=" + this.SQLiteFileName + ";Version=3;");
                this.dbConnection.Open();
            }
            catch
            {
                MessageBox.Show("Невозможно открыть файл базы данных " + this.SQLiteFileName + "!\nВозможно установлена защита от записи.", "Ошибка SQLite", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /*
         * Закрыть соединение с базой
         */
        public void Close()
        {
           // this.dbConnection.Close();
        }

        /*
         * Проверяет, есть ли соединение с БД SQLite
         */
        public bool isOpened()
        {
            bool opened = false;

            try
            {
                if (this.dbConnection.State == System.Data.ConnectionState.Open)
                {
                    opened = true;
                }
            }
            catch (SQLiteException)
            {
                return false;
            }
            return opened;
        }

        /*
         * Создает две таблицы для хранения параметров датчиков и показаний температуры
         */
        public void PrepareDB()
        {
            try
            {
                using (SQLiteTransaction sqlTransaction = this.dbConnection.BeginTransaction())
                {
                    using (SQLiteCommand sqlCommand = this.dbConnection.CreateCommand())
                    {
                        sqlCommand.Transaction = sqlTransaction;
                        sqlCommand.CommandText = this.sql_CreateSensorsTable;
                        sqlCommand.ExecuteNonQuery();
                        sqlCommand.CommandText = this.sql_CreateValuesTable;
                        sqlCommand.ExecuteNonQuery();
                    }
                    sqlTransaction.Commit();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка SQLite", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /*
         * Возвращает список датчиков, сохраненных в базе
         */
        public IDictionary<int, SensorData> ListDBSensors()
        {
            IDictionary<int, SensorData> result = new Dictionary<int, SensorData>();
            try
            {
                SQLiteCommand sql_Command = new SQLiteCommand("SELECT id, name, rom FROM 'sensors';", this.dbConnection);
                var sensorsData = sql_Command.ExecuteReader();
                while (sensorsData.Read())
                {
                    int _sensorID = Convert.ToInt32(sensorsData["id"]);
                    result.Add(_sensorID, new SensorData { sensorROM = sensorsData["rom"].ToString(), sensorName = sensorsData["name"].ToString() });
                }
            }
            catch (Exception)
            {
                result = null;
                //MessageBox.Show("Исключение: " + ex.Message + "\nОбъект: " + ex.TargetSite.ToString() + "\nДополнительно: " + ex.ToString(), "Исключение в главном модуле");
            }
            return result;
        }

        /*
         * Создает запрос к таблице значений температур на основе заданных аргументов 
         * @dbArgs типа SQLiteQueryArgs - структура аргументов к запросу SQL
         */
        public QueryResult QueryTempValues(SQLiteQueryArgs dbArgs)
        {
            IDictionary<DateTime, double> tValue = new Dictionary<DateTime, double>();
            TempStatistics sensorStats = new TempStatistics();

            QueryResult result = new QueryResult();
            SQLiteCommand sql_Command = new SQLiteCommand(this.dbConnection);
            SQLiteDataReader temperatureStats;

            float temperatureAVG = float.NaN;
            float temperatureMAX = float.NaN;
            float temperatureMIN = float.NaN;

            string sqlClause = string.Empty;

            if (dbArgs.sensorID > -1)
            {
                sqlClause = " sensorID='" + dbArgs.sensorID.ToString() + "'";
            }
            if (dbArgs.startPeriod != null)
            {
                if (sqlClause != string.Empty && sqlClause.Length > 0)
                {
                    sqlClause += " AND";
                }
                sqlClause += " date >= '" + dbArgs.startPeriod.ToString("yyyy-MM-dd HH:mm:ss") + "'";
            }
            if (dbArgs.endPeriod != null)
            {
                if (sqlClause != string.Empty && sqlClause.Length > 0)
                {
                    sqlClause += " AND";
                }
                sqlClause += " date <= '" + dbArgs.endPeriod.ToString("yyyy-MM-dd HH:mm:ss") + "'";
            }

            sqlClause += " ORDER BY date DESC";

            if (dbArgs.limit > 0)
            {
                sqlClause += " LIMIT " + dbArgs.limit.ToString();
            }

            if (sqlClause != string.Empty)
            {
                sqlClause = " WHERE" + sqlClause;
            }

            sql_Command.CommandText = "SELECT AVG(temperature) AS tAverage, MAX(temperature) as tMax, MIN(temperature) as tMin FROM temperatures" + sqlClause;
            temperatureStats = sql_Command.ExecuteReader();

            try
            {
                while (temperatureStats.Read())
                {
                    if (temperatureStats["tAverage"] != DBNull.Value)
                    {
                        temperatureAVG = (float)Convert.ToDouble(temperatureStats["tAverage"]);
                    }
                    if (temperatureStats["tMax"] != DBNull.Value)
                    {
                        temperatureMAX = (float)Convert.ToDouble(temperatureStats["tMax"]);
                    }
                    if (temperatureStats["tMin"] != DBNull.Value)
                    {
                        temperatureMIN = (float)Convert.ToDouble(temperatureStats["tMin"]);
                    }
                }

                sensorStats.tAvg = temperatureAVG;
                sensorStats.tMax = temperatureMAX;
                sensorStats.tMin = temperatureMIN;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Исключение: " + ex.Message + "\nОбъект: " + ex.TargetSite.ToString() + "\nДополнительно: " + ex.ToString(), "Исключение в главном модуле");
            }
            finally
            {
                temperatureStats.Close();
            }


            try
            {
                sql_Command.CommandText = "SELECT CAST(replace(temperature, ',', '.') as float) as temperature, date FROM 'temperatures'" + sqlClause + ";";
                var tempValue = sql_Command.ExecuteReader();
                while (tempValue.Read())
                {
                    double temperatureValue = Convert.ToDouble(tempValue["temperature"]);
                    if (dbArgs.removePeaks == true && temperatureAVG != double.NaN)
                    {
                        double delta = Math.Abs(temperatureValue - temperatureAVG);
                        if (delta > dbArgs.maxDelta)
                        {
                            continue;
                        }
                    }
                    tValue.Add(DateTime.Parse(tempValue["date"].ToString()), temperatureValue);
                }
                result.stats = sensorStats;
                result.tValue = tValue;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Исключение: " + ex.Message + "\nОбъект: " + ex.TargetSite.ToString() + "\nДополнительно: " + ex.ToString(), "Исключение в главном модуле");
            }

            return result;
        }

        /*
         * Добавляет новый датчик в таблицу (ROM и название)
         * Возвращает внутренний SQLite id добавленного датчика
         * если датчик с указанным ROM уже существует - возвращает его внутрениий id
         */
        public int UpdateSensor(string sensorROM, string sensorName)
        {
            int sqlite_SensorID = -1;

            // Проверяем, нет-ли уже такого датчика в базе
            SQLiteCommand sql_Command = new SQLiteCommand("SELECT id, name FROM 'sensors' WHERE rom='" + sensorROM + "' LIMIT 1;", this.dbConnection);
            var sensorData = sql_Command.ExecuteReader();
            if (sensorData.Read())
            {
                // Датчик есть - возвращаем его id
                sqlite_SensorID = Convert.ToInt32(sensorData["id"]);

                // Если изменилось имя датчика - заменим его и в базе
                if (sensorName != sensorData["name"].ToString())
                {
                    sensorData.Close();
                    sql_Command.CommandText = "UPDATE 'sensors' SET name='" + sensorName + "' WHERE id='" + sqlite_SensorID.ToString() + "';";
                    sql_Command.ExecuteNonQuery();
                    //Console.WriteLine(sensorData["name"]);
                }
            }
            else
            {
                sensorData.Close();
                // Датчика нет - добавлем его
                try
                {
                    sql_Command.CommandText = "INSERT INTO 'sensors' ('rom', 'name') VALUES('" + sensorROM + "','" + sensorName + "');";
                    sql_Command.ExecuteNonQuery();
                    sql_Command.CommandText = "select last_insert_rowid()";
                    Int64 LastRowID64 = (Int64)sql_Command.ExecuteScalar();
                    sqlite_SensorID = (int)LastRowID64;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка SQLite11");
                }
            }

            return sqlite_SensorID;
        }

        /*
         * Добавляет время и значение температуры указанного датчика в таблицу
         */
        public void InsertTempValue(int sqlite_SensorID, float tempValue)
        {
            try
            {
                SQLiteCommand sql_InsertCommand = new SQLiteCommand(this.dbConnection);
                sql_InsertCommand.CommandText = "INSERT INTO 'temperatures' ('sensorID', 'temperature', 'date') VALUES('" + sqlite_SensorID + "', '" + tempValue + "', DATETIME('now', 'localtime'));";
                sql_InsertCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка SQLite");
            } 
        }
    }
}
