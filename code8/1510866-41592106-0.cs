    public void ConfigureServices(IServiceCollection services)
    {
        // Adds services required for using options.
        services.AddOptions();
        // Registers the following lambda used to configure options.
        services.Configure<DocumentRendererOptions>(options => {
            Configuration.GetSection("DocumentRenderer").Bind(options)
        });
        //register other services
        services.AddSingleton<DocumentRenderer>();
    }
