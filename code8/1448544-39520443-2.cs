     public bool does_Column_Exist(string colName,string tableName)
        {
            bool ret = false;
            using (SqlConnection conn = getConn())
            {
                conn.Open();
                using (SqlCommand com = conn.CreateCommand())
                {
                    com.CommandText = "select count(*) from information_schema.COLUMNS where column_name = @col and table_name = @tab";
                    com.Parameters.AddWithValue("@tab", tableName);
                    com.Parameters.AddWithValue("@col", colName);
                    ret = Convert.ToInt32(com.ExecuteScalar()) == 0 ? false : true; 
                }
                conn.Close();
            }
            return ret;
        }
