    services.AddScoped<IMongoDatabase>(provider => {
        var settings = provider.GetService<IOptions<DbSettings>>
        var client = new MongoClient(settings.Value.ConnectionString);
        return client.GetDatabase(settings.Value.Database);
    });
    services.AddScoped<IDbContext, DbContext>();
    services.AddScoped<ILogItemRepository, LogItemRepository>();
