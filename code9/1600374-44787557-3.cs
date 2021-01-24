    public void ConfigureServices(IServiceCollection services)
    {
        services.AddOptions();
        services.Configure<DatabaseConnections>(
            Configuration.GetSection("DatabaseConnections"));
    
    
        var sp = services.BuildServiceProvider();
        var databaseConnections = sp.GetService<IOptions<DatabaseConnections>>();
    
        services.AddSingleton<IDocumentClient>(
            new DocumentClient(new Uri(databaseConnections.Value.DatabaseUri)),
            databaseConnections.Value.ApplicationKey));
    }
