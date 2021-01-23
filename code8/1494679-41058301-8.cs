    public void ConfigureServices(IServiceCollection services)
    {
        services.AddDbContext<MyDbContext>(options =>
        options.UseSqlServer(Configuration["ConnectionStrings:DefaultConnection"]));
        services.AddMvc();
        services.AddScoped<IMyService, MyService>();
    }
