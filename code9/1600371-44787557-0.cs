    public void ConfigureServices(IServiceCollection services)
    {
        services.AddOptions();
        services.Configure<DatabaseConnections>(
               Configuration.GetSection("DatabaseConnections"));
    
        services.AddSingleton<IDocumentClient>(
            new DocumentClient(
                new Uri(Configuration.GetSection("DatabaseConnections:DatabaseUri").Value)),
                Configuration.GetSection("DatabaseConnections:ApplicationKey").Value));
    }
