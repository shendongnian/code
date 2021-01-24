    public void ConfigureServices(IServiceCollection services)
    {
        services.ConfigureOptionsFromAssemblies(configuration, new List<Assembly>()
        {
            typeof(ConnectionStrings).Assembly
        });
       ...
    }
