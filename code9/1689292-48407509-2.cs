    public void ConfigureServices(IServiceCollection services)
    {
        services.AddTransient<HubMethods<MyHub>>();
        services.AddSignalR();
        services.AddMvc();
    }
