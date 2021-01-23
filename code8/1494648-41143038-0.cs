    private void AddConfigurationSettingsSingleton(IServiceCollection services)
    {
        var config = new Settings();
        Configuration.GetSection("Settings").Bind(config);
        services.AddSingleton(config);
    }
