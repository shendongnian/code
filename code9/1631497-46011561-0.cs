    public void ConfigureServices(IServiceCollection services)
    {
        services.AddMvc();
        services.AddScoped<IMyService, MyService>();
    }
