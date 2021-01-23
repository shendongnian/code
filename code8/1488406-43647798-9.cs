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
    var specificConnStr1 = connectionStrings["Test1"];
    Console.WriteLine(specificConnStr1.Name);
    Console.WriteLine(specificConnStr1.ConnectionString);
    Console.WriteLine(specificConnStr1.ProviderName);
    var specificConnStr2 = configuration.ConnectionString("Test2");
    Console.WriteLine(specificConnStr2.Name);
    Console.WriteLine(specificConnStr2.ConnectionString);
    Console.WriteLine(specificConnStr2.ProviderName);
