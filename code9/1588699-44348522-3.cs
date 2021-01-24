    public void ConfigureServices(IServiceCollection services)
    {
        services.AddScoped<Database>((provider) =>
        {
            return new DatabaseWithMVCMiniProfiler("MainConnectionString");
        });
    }
    
