    var connection = new SqliteConnection(connectionString);
    _connection.StateChange += (sender, e) =>
    {
        if (e.OriginalState != ConnectionState.Open)
            return;
        var senderConnection = (DbConnection)sender;
        using (var command = senderConnection.CreateCommand())
        {
            command.Connection = senderConnection;
            command.CommandText = "-- TODO: Put little SQL command here.";
            command.ExecuteNonQuery();
        }
    };
    optionsBuilder.UseSqlite(connection);
