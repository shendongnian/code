    public void ConfigureServices(IServiceCollection services)
    {
        services.AddLogging(lb =>
        {
            lb.AddConfiguration(Configuration.GetSection("Logging"));
            lb.AddFile(o => o.RootPath = AppContext.BaseDirectory);
        });
    }
