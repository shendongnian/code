    public void ConfigureServices(IServiceCollection services) {
        // Add framework services.
        services
            .AddEntityFramework()
            .AddSqlServer()
            .AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnextionString("DefaultConnection")))
            .AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnextionString("FooBar")));
    }
