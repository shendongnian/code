        public SqlConnection OpenSqlConnection(string connectionString)
        {
            var conn = new SqlConnection(connectionString);
            var retries = 10;
            while (conn.State != ConnectionState.Open && retries > 0)
            {
                try
                {
                    conn.Open();
                }
                catch (Exception)
                {
                    
                }
                Thread.Sleep(500);
                retries--;
            }
            
            _connectionString = connectionString;
            var sb = new SqlConnectionStringBuilder(_connectionString);
            _server = sb.DataSource;
            _database = sb.InitialCatalog;
            return conn;
        }
