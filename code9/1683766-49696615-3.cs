    public void ConfigureServices(IServiceCollection services)
    {
        services.AddMvc();
        services.AddOptions();            
        services.Configure<MyAppSettings>(Configuration.GetSection("MyAppSettings"));
        services.AddSingleton(Configuration);        
        services.AddSingleton<ISettingsDecrypt, SettingsDecryptor>();
        services.AddScoped<IAppSettings, MyAppSettingsBridge>();
    }
