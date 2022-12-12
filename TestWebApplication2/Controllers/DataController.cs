/***********************************
** DataController.cs
** Author: Pooja Prasanna Nanjunda
** Email: poojananjunda1996@gmail.com
** Date: 04-12-2022
***********************************/

namespace TestWebApplication2.Controllers
{
    using System.Data.SQLite;
    using Microsoft.AspNetCore.Mvc;
    using TestWebApplication2.Models;

    /// <summary>
    /// This class implements DataController to process the data.
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class DataController : ControllerBase
    {
        IConfiguration Configuration;

        /// <summary>
        /// The sQLite connection object.
        /// </summary>
        private SQLiteConnection? sQLiteConnection;

        private ConfigurationParameters settings;

        /// <summary>
        /// Initializes a new instance of the <see cref="DataController"/> class.
        /// </summary>
        public DataController(IConfiguration configuration)
        {
            this.Configuration = configuration;

            this.settings = new ConfigurationParameters()
            {
                DatabasePath = configuration.GetValue<string>("ConfigurationParameters:DatabasePath"),
            };

            // Create the database folder structure if it does not exist
            if (!Directory.Exists(this.settings.DatabasePath))
            {
                Directory.CreateDirectory(this.settings.DatabasePath);
            }
            var dataSource = Path.Combine(this.settings.DatabasePath, "TestDatabase.db");

            // create the connection to sqlite database.
            this.sQLiteConnection = this.CreateConnection(dataSource);

            // exit the application if the database connection is not created.
            if (this.sQLiteConnection == null)
            {
                Environment.Exit(1);
            }

            // create table if table not created.
            if (!this.CreateTableIfNotExists())
            {
                Environment.Exit(1);
            }
        }

        /// <summary>
        /// This method will be invoked on http get request.
        /// This method gets the data inserted by the win form application from the DataTable.
        /// </summary>
        /// <returns>The list of data present in the DataTable.</returns>
        [HttpGet]
        public ActionResult<List<DataParameters>> GetData()
        {
            var result = this.ReadDataTable();
            if (result == null)
            {
                Environment.Exit(1);
            }

            return result;
        }

        /// <summary>
        /// This method will be invoked on http post request.
        /// This method inserts the data into the DataTable along with the application identifier.
        /// </summary>
        /// <param name="dataParameters">The data parameters.</param>
        /// <returns>The Action Result.</returns>
        [HttpPost]
        public IActionResult PostData(DataParameters dataParameters)
        {
            if (!this.InsertDataIntoTheTable(dataParameters.DataText))
            {
                Environment.Exit(1);
            }

            return this.CreatedAtAction(nameof(this.PostData), new DataParameters { DataText = dataParameters.DataText }, dataParameters);
        }

        /// <summary>
        /// This method creates the table if the table is not created in the database.
        /// </summary>
        /// <returns>true if the operation is successful, false if there is an error or exception.</returns>
        private bool CreateTableIfNotExists()
        {
            try
            {
                // create DataTable
                SQLiteCommand sqlite_cmd;
                string createTestTable1 = "CREATE TABLE IF NOT EXISTS DataTable (TextData VARCHAR(200), Sender VARCHAR(100))";
                sqlite_cmd = this.sQLiteConnection.CreateCommand();
                sqlite_cmd.CommandText = createTestTable1;
                sqlite_cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// This method reads the table and returns the data that are inserted by the Win form application.
        /// </summary>
        /// <returns>A list of DataParameters object.</returns>
        private List<DataParameters> ReadDataTable()
        {
            try
            {
                var dataTextList = new List<DataParameters>();
                SQLiteDataReader sqlite_datareader;
                SQLiteCommand sqlite_cmd;
                sqlite_cmd = this.sQLiteConnection.CreateCommand();
                sqlite_cmd.CommandText = "SELECT TextData, Sender FROM DataTable WHERE Sender != 'WebApplication'";

                sqlite_datareader = sqlite_cmd.ExecuteReader();
                while (sqlite_datareader.Read())
                {
                    string textData = sqlite_datareader.GetString(0);
                    string sender = sqlite_datareader.GetString(1);
                    if (!string.IsNullOrEmpty(textData) && !string.IsNullOrEmpty(sender))
                    {
                        dataTextList.Add(new DataParameters() { DataText = $"Message: {textData} sent from Sender: {sender}" });
                    }
                }

                return dataTextList;
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// This method creates the connection to the database.
        /// </summary>
        /// <returns>The connection object.</returns>
        private SQLiteConnection CreateConnection(string dataSource)
        {
            SQLiteConnection sqlite_conn;
            try
            {
                // Create a new database connection:
                sqlite_conn = new SQLiteConnection($"Data Source= {dataSource} ; Version = 3; New = True; Compress = True; ");

                // Open the connection:
                sqlite_conn.Open();
            }
            catch (Exception)
            {
                return null;
            }

            return sqlite_conn;
        }

        /// <summary>
        /// This method inserts the input text and the sender into the DataTable.
        /// </summary>
        /// <param name="input">The input text.</param>
        /// <returns>true if the insert operation is successful. Returns false otherwise.</returns>
        private bool InsertDataIntoTheTable(string input)
        {
            try
            {
                SQLiteCommand sqlite_cmd;
                sqlite_cmd = this.sQLiteConnection.CreateCommand();
                sqlite_cmd.CommandText = $"INSERT INTO DataTable (TextData, Sender) VALUES('{input}', 'WebApplication');";
                sqlite_cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
