    public void ConfigureServices(IServiceCollection services)
            {
                var jwtSettings = new JwtSettings();
                Configuration.Bind(jwtSettings);
                services.AddSingleton(jwtSettings);
    
                var databaseSettings = new DatabaseSettings();
                Configuration.Bind(databaseSettings);
                services.AddSingleton(databaseSettings);
    
    
                services.AddControllersWithViews();
            }
