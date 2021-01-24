    using (MySqlConnection connection = new MySqlConnection(connectionString))
    {
     connection.Open();
     Console.WriteLine(connection.State);
    }
