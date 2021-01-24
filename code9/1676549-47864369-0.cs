    var configuration = new ConfigurationBuilder()
        .AddJsonFile("config.json", optional: false)
        .Build();
    
    var services = new ServiceCollection();
    services.AddOptions();
    
    // add your services here
    services.AddTransient<MyService>();
    services.AddTransient<Program>();
    
    // configure options
    services.Configure<AppSettings>(configuration.GetSection("App"));
    
    // build service provider
    var serviceProvider = services.BuildServiceProvider();
    
    // retrieve main application instance and run the program
    var program = serviceProvider.GetService<Program>();
    program.Run();
