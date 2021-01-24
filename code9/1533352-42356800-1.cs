    public void ConfigureServices(IServiceCollection services)
    {
        services.AddDbContext<SampleDBContext>(options =>
            options.UseSqlServer(Configuration["Data:DefaultConnection:ConnectionString"])
            );
    }
