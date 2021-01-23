    public void ConfigureServices(IServiceCollection services)
    {
        // Add framework services.
        services.AddMvc();
        services.AddOptions();
        services.Configure<MyConfiguration>(Configuration.GetSection("MyConfiguration"));
    }
