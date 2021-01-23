    public static void Main(string[] args)
    {
        IConfigurationBuilder configBuilderForMain = new ConfigurationBuilder();
        ConfigureConfiguration(configBuilderForMain);
        IConfiguration configForMain = configBuilderForMain.Build();
        
        // ... use configForMain to read config here ...
        var host = new WebHostBuilder()
            .ConfigureAppConfiguration(ConfigureConfiguration)
            // ... the rest of it ...
            .Build();
    }
    
    public static void ConfigureConfiguration(IConfigurationBuilder config)
    {
        config.SetBasePath(Directory.GetCurrentDirectory());
        .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
    }
