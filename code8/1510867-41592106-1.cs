    public void ConfigureServices(IServiceCollection services)
    {
        // Adds services required for using options.
        services.AddOptions();
        // Registers the following lambda used to configure options.
        services.Configure<DocumentRendererOptions>(Configuration.GetSection("DocumentRenderer"));
        //register other services
        services.AddSingleton<DocumentRenderer>();
    }
