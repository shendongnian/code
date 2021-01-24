     class Example 
    {
        private string m_sConnectionString;
        private OracleConnection m_dbConnection = null;
        public OracleConnection Connection
        {
            get
            {
                if (null == m_dbConnection)
                {
                    m_dbConnection = new OracleConnection(m_sConnectionString);
                }
                return m_dbConnection;
            }
        }
        /// <summary>
        /// Open the connection
        /// </summary>
        public void Open()
        {
            if (Connection.State != ConnectionState.Open)
                Connection.Open();
        }
        /// <summary>
        /// Close the connection
        /// </summary>
        public void Close()
        {
            try
            {
                if (null == m_dbConnection)
                    return;
                m_dbConnection.Close();
            }
            catch { }
        }
        /// <summary>
        /// Execucte a SQL command, with open a new connection
        /// </summary>
        /// <param name="query">The SQL Query</param>
        public void Execute(string query)
        {
            Open();
            using (OracleCommand dbSqlCmd = Connection.CreateCommand())
            {
                dbSqlCmd.CommandText = query;
                dbSqlCmd.ExecuteNonQuery();
                dbSqlCmd.Dispose();
            }
        }
       
        public void Connect(string schema, string password, string datasource)
        {           
            OracleConnectionStringBuilder conn_builder = new OracleConnectionStringBuilder();
            conn_builder.DataSource = datasource.Replace("/", @"\"); //Replace the / with a \ (standard path);           
            conn_builder.Add("Password", password);
            conn_builder.Add("User ID", schema);
            conn_builder.Pooling = true;
            conn_builder.MaxPoolSize = 40;
            conn_builder.MinPoolSize = 40;          
            conn_builder.Unicode = true;
            m_sConnectionString = conn_builder.ConnectionString;            
        }
    }
