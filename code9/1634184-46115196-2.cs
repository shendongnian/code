    using (var connection = context.Database.GetDbConnection()) {
        await connection.OpenAsync();     
        using (var command = connection.CreateCommand()) {
            command.CommandText = "DELETE FROM [Blogs]";
            var result = await command.ExecuteNonQueryAsync();
        }
    }
