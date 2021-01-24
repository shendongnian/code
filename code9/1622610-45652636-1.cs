    public void ConfigureServices(IServiceCollection services) {
        var _configManager = new ConfigManager(_config); //Create new instance
        services.AddSingleton<IConfigManager>(provider => _configManager); // add as singleton
        services.AddDbContext<CustomDbContext>(options => 
            options.UseSqlite(_configManager._config.ConnectionStrings.FirstOrDefault(c => c.id == "IdentityDatabase").connectionString)
        );
        services.AddIdentity<CustomIdentity, CustomRole>(config => {
            config.SignIn.RequireConfirmedEmail = true;
        })
            .AddEntityFrameworkStores<CustomDbContext>()
            .AddDefaultTokenProviders();
        services.AddIdentityServer()
            .AddInMemoryClients(_configManager.GetClients())
            .AddInMemoryIdentityResources(_configManager.GetIdentityResources())
            .AddInMemoryApiResources(_configManager.GetApiResources())
            .AddTemporarySigningCredential()
            .AddAspNetIdentity<CustomIdentity>();
    
    }
