    public void ConfigureServices(IServiceCollection services)
    {
        services.AddLogging(lb =>
        {
            lb.AddConfiguration(Configuration.GetSection("Logging"));
            lb.AddFile(new FileLoggerContext(AppContext.BaseDirectory, "fallback.log"));
        });
        services.Configure<FileLoggerOptions>(Configuration.GetSection("Logging:File"));
    }
