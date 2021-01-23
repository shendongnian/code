    var serverConnection = new ServerConnection("serverName", "username", "password");
    var server = new Server(serverConnection);
    var database = server.Databases["databaseName"];
    var table = database.Tables["tableName"];
    foreach (Column column in table.Columns)
    {
        Console.WriteLine($"{column.Name} - default constraint: {column.DefaultConstraint?.Text ?? "None"}");
    }
    Console.ReadLine();
