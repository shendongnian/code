    public static void FillWithDataReader(string query, Action<IDataRecord> filler)
    {
        using (MySqlConnection connection = new MySqlConnection(_connectionString))
        {
            connection.Open();
            using (MySqlCommand command = new MySqlCommand(query, connection))
            {
                MySqlDataReader reader = command.ExecuteReader();
                while(reader.Read())
                    filler(reader);
            }
        }
    }
