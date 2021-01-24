    public void ConfigureServices(IServiceCollection services)
    {
        // Connect to Redis database.
        var redis = ConnectionMultiplexer.Connect("<URI>");
        services.AddDataProtection()
            .PersistKeysToRedis(redis, "DataProtection-Keys");
        services.AddMvc();
    }
