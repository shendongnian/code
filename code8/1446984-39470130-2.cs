     //these are connection methods that help connect you to your database manually.
     public SqlConnection getConn()
        {
            return new SqlConnection(getConnString());
        }
        public string getConnString()
        {
            return @"Data Source=lily.arvixe.com;Initial Catalog={My_Database_Name};Persist Security Info=True;User ID={My_Database_Username};Password={My_Database_Password};Connection Timeout=7000";
        }
       //to get a single value from a single field:
       public object scalar(string sql)
        {
            object ret;
            using (SqlConnection conn = getConn())
            {
                conn.Open();
                using (SqlCommand com = conn.CreateCommand())
                {
                    com.CommandText = sql;
                    ret = com.ExecuteScalar();
                }
                conn.Close();
            }
            return ret;
        }
        //To do a SELECT with multiple rows returned
        private List<string> get_Column_Names(string tableName)
        {
            List<string> ret = new List<string>();
            using (SqlConnection conn = getConn())
            {
                conn.Open();
                using(SqlCommand com = conn.CreateCommand())
                {
                    com.CommandText = "select column_Name from INFORMATION_SCHEMA.COLUMNS where table_Name = '" + tableName + "'";
                    com.CommandTimeout = 600;
                    SqlDataReader read = com.ExecuteReader();
                    while (read.Read())
                    {
                        ret.Add(Convert.ToString(read[0]));
                    }
                }
                conn.Close();
            }
            return ret;
        }
        // to do an INSERT or UPDATE or anything that does not return data
        // USE PARAMETERS if people go anywhere near this data
        public void nonQuery(string sql)
        {
            using(SqlConnection conn = getConn())
            {
                conn.Open();
                using(SqlCommand com = conn.CreateCommand())
                {
                    com.CommandText = sql;
                    com.CommandTimeout = 5900;
                    com.ExecuteNonQuery();
                }
                conn.Close();
            }
            
        }
        //to save a DataTable manually:
        public void saveDataTable(string tableName, DataTable table)
        {
            using (SqlConnection conn = getConn())
            {
                conn.Open();
                using (var bulkCopy = new SqlBulkCopy(conn))//, SqlBulkCopyOptions.KeepIdentity))
                {
                    // my DataTable column names match my SQL Column names, so I simply made this loop. However if your column names don't match, just pass in which datatable name matches the SQL column name in Column Mappings
                    foreach (DataColumn col in table.Columns)
                    {
                        bulkCopy.ColumnMappings.Add(col.ColumnName, "[" + col.ColumnName + "]");
                    }
                    bulkCopy.BulkCopyTimeout = 8000;
                    bulkCopy.DestinationTableName = tableName;
                    bulkCopy.BatchSize = 10000;
                    bulkCopy.EnableStreaming = true;
                    // bulkCopy.SqlRowsCopied += BulkCopy_SqlRowsCopied;
                    //bulkCopy.NotifyAfter = 10000;
                    //isCopyInProgess = true;
                    bulkCopy.WriteToServer(table);
                }
                conn.Close();
            }
        }
       
