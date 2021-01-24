    services.AddDbContext<AppDbContext>(options =>
        options.UseSqlServer(Configuration["database:appConnectionString"]));
    services.AddDbContext<LogDbContext>(options =>
        options.UseSqlServer(Configuration["database:logConnectionString"]));
    services.AddScoped(typeof(IRepository<,>), typeof(GenericRepository<,>));   
    services.AddScoped<IAppDbContext, AppDbContext>();
    services.AddScoped<ILogDbContext, LogDbContext>();
