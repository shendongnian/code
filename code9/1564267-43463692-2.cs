    public void ConfigureServices(IServiceCollection services)
    {
        ...
    
        // Add EF services to the services container.
        services.AddEntityFramework()
            .AddSqlServer()
            .AddDbContext<TestDbContext>(options =>
                options.UseSqlServer(Configuration["Data:DefaultConnection:ConnectionString"]));
    
    	// Register the service and implementation for the database context
    	services.AddScoped<ITestDbContext>(provider => provider.GetService<TestDbContext>());
    
      //	...
    }
