    public Startup(IHostingEnvironment env)
    {
        IConfigurationBuilder builder = new ConfigurationBuilder()
            .SetBasePath(env.ContentRootPath)
            .AddJsonFile("appsettings.json", false, true)
            .AddJsonFile($"appsettings.{env.EnvironmentName}.json")
            .AddEnvironmentVariables();
        // ...
    }
    public void ConfigureServices(IServiceCollection services)
    {
        // Add framework services.
        services.AddDbContext<MyDbContext>(
            options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"),
            sqlOptions => sqlOptions.EnableRetryOnFailure()));
        // SQL configuration for non-injected dbcontext
        DbContextOptionsBuilder<MyDbContext> builder = new DbContextOptionsBuilder<MyDbContext>();
        builder.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
        services.AddSingleton(builder.Options);
        // ...
    }
