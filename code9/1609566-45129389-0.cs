    public Startup(IHostingEnvironment env)
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(env.ContentRootPath)
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
            .AddEnvironmentVariables();
        Configuration = builder.Build();
    
        MmHelper.InitializeMapper();
    }
    
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddDbContext<AppDbContext>();
    
        services.AddIdentity<User, IdentityRole>()
            .AddEntityFrameworkStores<AppDbContext>()
            .AddDefaultTokenProviders();
        
        // ....
    
        Scheduler.Start(services.BuildServiceProvider());
    }
