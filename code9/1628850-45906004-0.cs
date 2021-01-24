    public void ConfigureServices(IServiceCollection services)
    {
        services.AddMvc();
    
        var connection = @"Server=(localdb)\mssqllocaldb;Database=EFGetStarted.AspNetCore.NewDb;Trusted_Connection=True;";
        services.AddDbContext<MyContext>(options => options.UseSqlServer(connection));
    }
