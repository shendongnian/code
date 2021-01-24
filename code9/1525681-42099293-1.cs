    // Add framework services.
    var userSettingsConfig = new UserSettingsConfig();
    Configuration.GetSection("UserSettings").Bind(userSettingsConfig);
    services.Configure<UserSettingsConfig>(Configuration.GetSection("UserSettings"));
    
    services.AddMvc();
    services.AddScoped<DevOnlyActionFilter>();
    
    services.AddDataProtection()
    	.SetApplicationName(userSettingsConfig.appName)
    	.PersistKeysToFileSystem(userSettingsConfig.DirInfo);
