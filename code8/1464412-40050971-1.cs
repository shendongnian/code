    using (var connection = new SqlConnection("connectionString"))
    {
        var serverConnection = new ServerConnection(connection);
        var server = new Server(serverConnection);
        var database = server.Databases["databaseName"];
        var table = database.Tables["tableName"];
        foreach (Column column in table.Columns)
        {
            Console.WriteLine($"{column.Name} - default constraint: {column.DefaultConstraint?.Text ?? "None"}");
        }
        Console.ReadLine();
    }
