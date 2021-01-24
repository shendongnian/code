    public void ConfigureServices(IServiceCollection services)
    {           
        services.AddSingleton<IAppSettings>(settings);
        services.AddSingleton<IHttpContextAccessor>(new HttpContextAccessor());
        …
     }
