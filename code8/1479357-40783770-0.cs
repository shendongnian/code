    using (var connection = _context.Database.GetDbConnection())
    {
        connection.Open();
     
        using (var command = connection.CreateCommand())
        {
            command.CommandText = "SELECT COUNT(*) FROM People WHERE Type = 1";
            var result = command.ExecuteScalar().ToString();
        }
    }
