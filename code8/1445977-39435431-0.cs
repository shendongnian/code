    public void ConfigureServices(IServiceCollection services)
      {
        var connection = @"Server=(localdb)\mssqllocaldb;Database=MyDb;Trusted_Connection=True;";
        services.AddDbContext<ShoppingDbContext>(options => options.UseSqlServer(connection));
    }
