        // Startup.ConfigureServices
        services.AddDbContext<DbContext>(config => 
        {
            config.UseSqlServer(Configuration.GetConnectionString("Default"));
        });
    and configure it in your appsettings.json
        {
            "ConnectionStrings": {
                "Default": "YourSQLConnectionStringHere"
            }
        }
