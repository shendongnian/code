    public void ConfigureServices(IServiceCollection services) {
        
        services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
        services.AddTransient<IUnitOfWork, UnitOfWork>();
        services.AddMvc();
    }
