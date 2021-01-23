    private async Task ExecuteNonQueryAsync(string commandText)
    {
        using (var connection = new SqlConnection(connectionString)
        using (var command = new SqlCommand(commandText, connection))
        {
            connection.Open();
            /* int rowsAffected = */ await command.ExecuteNonQueryAsync();
            connection.Close();
        }
    }
