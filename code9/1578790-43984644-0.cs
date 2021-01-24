    public void ConfigureServices(IServiceCollection services)
    {
        // Add framework services.
        services.AddEntityFramework()
            .AddSqlServer()
            .AddDbContext<YourUserStoreDbContextHere>(options =>
                options.UseSqlServer(Configuration["Data:DefaultConnection:ConnectionString"]));
    
        services.AddIdentity<YourUserClassHere, YourRoleClassHereIfAny>()
            .AddEntityFrameworkStores<YourUserStoreDbContextHere>()
            .AddDefaultTokenProviders();
    
        services.AddIdentityServer()
            // Other config here
            .AddAspNetIdentity<YourUserClassHere>();
    }
