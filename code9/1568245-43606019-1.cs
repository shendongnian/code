    public void ConfigureServices(IServiceCollection services)
    {
        services.AddDbContext<MyDbContext>(options =>    
        options.UseSqlServer(Configuration.GetConnectionString("MyDatabase")));
    }
