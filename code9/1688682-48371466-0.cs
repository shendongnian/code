    var services = new ServiceCollection();
    var connection = @"Server = (localdb)\mssqllocaldb; Database = CryptoCurrency; Trusted_Connection = True; ConnectRetryCount = 0";
    services.AddDbContext<CurrencyDbContext>(options => options.UseSqlServer(connection));
    //...add any other services needed
    services.AddTransient<AutoGetCurrency>();
    //...
    ////then build provider 
    var serviceProvider = services.BuildServiceProvider();
    
