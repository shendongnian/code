    private static string connString = "server=127.0.0.1; userid=yourUserHere; password=youPasswordHere; database=yourDatabaseNameHere";
    public static DataTable SelectData(MySqlCommand command)
            {
                try
                {
                    DataTable dataTable = new DataTable();
    
                    using (MySqlConnection connection = new MySqlConnection())
                    {
                        connection.ConnectionString = connString;
                        connection.Open();
    
                        command.Connection = connection;
                        MySqlDataReader reader = command.ExecuteReader();
                        dataTable.Load(reader);
    
                        return dataTable;
                    }
                }
                catch (MySqlException e)
                {
                    Console.Write(e.Message);
                    return null;
                }
            }
