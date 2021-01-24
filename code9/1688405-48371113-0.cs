      public DataTable query(string sql) {
    
                DataTable table = new DataTable();
                MySqlConnection connection = null;
                MySqlDataReader reader = null;
    
                try {
                    connection = new MySqlConnection(xxx);
                    connection.Open();
                    MySqlDataAdapter dataAdapter = new MySqlDataAdapter();
                    dataAdapter.SelectCommand = new MySqlCommand(sql, connection);
                    dataAdapter.Fill(table);
                    
                    return table;
                } catch {
                    return table;
                } finally {
    
                    if (reader != null)
                        reader.Close();
                    if (connection != null)
                        connection.Close();
                }}
