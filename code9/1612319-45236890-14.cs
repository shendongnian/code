    public void ConfigureServices(IServiceCollection services) {
        // Add framework services.
        services.AddDbContext<AppDbContext>(options => 
        options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
        services.AddMvc();
    
        //Enable use of appsettings.json outside of Startup.cs
        services.AddSingleton(Configuration);
        services.AddSingleton<IConfiguration>(Configuration);
    
        services.AddSingleton<IAppDbContextFactory, AppDbContextFactory>();
        services.AddTransient<ISimRepository, SimRepository>();
    }
