    var configuration = new ConfigurationBuilder()
        .AddJsonFile("config.json")
        .Build();
    
    var connectionStrings = configuration.ConnectionStrings();
    
    foreach (var connectionString in connectionStrings.Values)
    {
        Console.WriteLine(connectionString.Name);
        Console.WriteLine(connectionString.ConnectionString);
        Console.WriteLine(connectionString.ProviderName);
    }
    
    var specificConnStr = configuration.ConnectionString("Test1");
    Console.WriteLine(specificConnStr.Name);
    Console.WriteLine(specificConnStr.ConnectionString);
    Console.WriteLine(specificConnStr.ProviderName);
