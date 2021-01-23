    Task SaveResultAsync(ResultObject result)
    {
        var query = "INSERT ...."
        using (var conn = new MySqlConnection(connectionString))
        using (var command = new MySqlCommand(conn, query)
        {
            // command.AddParameter for values you want to insert
            await conn.OpenAsync();
            await command.ExecuteNonQueryAsync();
        }
    }
