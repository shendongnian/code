    using (MySqlConnection MySqlConnection = new MySqlConnection(connectionString))
    using (MySqlCommand sqlCommand = new MySqlCommand(procedureName, MySqlConnection))
    {
        MySqlConnection.Open();
        sqlCommand.CommandType = CommandType.StoredProcedure;
        // ADD THIS
        sqlCommand.CommandText = "sp_criteria";
