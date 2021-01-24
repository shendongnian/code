    class MySQLClass : IDisposable
    {
        // Connection string need to be replaced for secure purpuose
        private static string connString = @"Server=xxxx;uid=xxxx;pwd=xxxxx;database=xxxxxx";
        /// <summary>
        /// OdbcConnection : This is the connection
        /// </summary>
        SqlConnection oConnection;
        /// <summary>
        /// OdbcCommand : This is the command
        /// </summary>
        SqlCommand oCommand;
        /// <summary>
        /// Constructor: This is the constructor
        /// </summary>
        /// <param name="DataSourceName">string: This is the data source name</param>
        public MySQLClass()
        {
            //Instantiate the connection
            oConnection = new SqlConnection(connString);
            try
            {
                //Open the connection
                oConnection.Open();
                //Notify the user that the connection is opened
                //Console.WriteLine("The connection is established with the database");
            }
            catch (OdbcException caught)
            {
                Console.WriteLine(caught.Message);
                Console.Read();
            }
        }
        /// <summary>
        /// void: It is used to close the connection if you work within disconnected
        /// mode
        /// </summary>
        public void CloseConnection()
        {
            oConnection.Close();
        }
        /// <summary>
        /// OdbcCommand: This function returns a valid odbc connection
        /// </summary>
        /// <param name="Query">string: This is the MySQL query</param>
        /// <returns></returns>
        public SqlCommand GetCommand(string Query)
        {
            oCommand = new SqlCommand();
            oCommand.Connection = oConnection;
            oCommand.CommandText = Query;
            return oCommand;
        }
        /// <summary>
        /// void: This method close the actual connection
        /// </summary>
        public void Dispose()
        {
            oConnection.Close();
        }
    }
