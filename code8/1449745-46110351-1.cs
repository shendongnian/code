    private IEnumerable<int> GetIds()
    {
        using (MySqlConnection connection = new MySqlConnection(connectionString))
        {
            connection.Open();
            string commandText = @"SELECT id FROM jsontest"; // Assuming that `orders` is your database, then you do not need to specify it here.
    
            using (MySqlCommand command = new MySqlCommand(commandText, connection))
            {
                MySqlDataReader reader = command.ExecuteReader();
    
                while (reader.Read())
                {
                    yield return reader.GetInt32(0);
                }
            }
        }
    }
