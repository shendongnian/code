    public void ConfigureServices(IServiceCollection services)
    {
        services.AddDataProtection()
            .SetApplicationName("shared app name");
    }
