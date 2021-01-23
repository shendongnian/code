    public void ConfigureServices(IServiceCollection services)
    {
        services.AddLogging(lb =>
        {
            lb.AddConfiguration(config.GetSection("Logging"));
            lb.AddFile(new FileLoggerContext(AppContext.BaseDirectory, "fallback.log"));
        }
        services.Configure<FileLoggerOptions>(config.GetSection("Logging:File"));
    });
