    public static MySqlDataReader Query(string SQLQuery, Action<MySqlDataReader> loader)
    {
        using (MySqlConnection con = new MySqlConnection(connectionString))
        {
            con.Open();
            using(MySqlCommand command = new MySqlCommand(SQLQuery, con))
            using(MySqlDataReader reader = command.ExecuteReader())
            {
               // here you can pass the reader, you are still inside the using block
               while(reader.Read())
                  loader.Invoke(reader)
            }
        }
    }
