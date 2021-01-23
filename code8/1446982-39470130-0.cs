     public SqlConnection getConn()
        {
            return new SqlConnection(getConnString());
        }
        public string getConnString()
        {
            return @"Data Source=lily.arvixe.com;Initial Catalog=WM_Crawler;Persist Security Info=True;User ID=;Password=;Connection Timeout=7000";
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
       //to save a datatable manually
