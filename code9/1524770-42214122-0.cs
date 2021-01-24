    ConnectionOptions opts = new ConnectionOptions();
    opts.HostName = "localhost";
    opts.UserName = "root";
    opts.Password = "mypassword";
    opts.Port = 2424;
    opts.DatabaseName = "mydatabasename";
    opts.DatabaseType = ODatabaseType.Graph;
    database = new ODatabase(opts);
    Console.Write(database.Size);
