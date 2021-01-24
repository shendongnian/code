    String connectionString = "This is your connection string";  
    public static int updateTable(string query)
            {
              
                using (MySqlConnection con = new MySqlConnection(connectionString))
                {
                    con.Open();
                    using (MySqlCommand cmd = con.CreateCommand())
                    {
                       cmd.CommandText = query;
                        cmd.CommandType = CommandType.Text;
                        int result = cmd.ExecuteNonQuery();
                        return result;
                    }
                }
            }
    
    To use this:
     updateTable("update yourtable set column1=value1, column2 = value2 where primarycolumn = primaryKeyValue");
