    public void ConfigureServices(IServiceCollection services)
    {
        services.AddMvc();
        services.AddDbContext<ZPHSContext>(options => options.UseSqlServer(Configuration.GetConnectionString("BloggingDatabase")));
    }
        
