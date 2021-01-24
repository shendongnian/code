    public void ConfigureServices(IServiceCollection services)
    {
        var connectionString = Configuration.GetConnectionString("MyConnectionString");
        services.AddScoped<IMyRepository>(sp => new MyRepository(connectionString));
    }
