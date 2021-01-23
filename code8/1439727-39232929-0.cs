    public void ConfigureServices(IServiceCollection services)
    {
       services.AddSingleton<IConfiguration>(Configuration);
    
       // ...
    }
