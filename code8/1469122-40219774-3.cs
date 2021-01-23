    public void ConfigureServices(IServiceCollection services)
    {
        var connection = Configuration["Production:SqliteConnectionString"];
    
        services.AddDbContext<MyContext>(options =>
            options.UseSqlite(connection)
        );
        ....
     }
