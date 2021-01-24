    services.AddDbContext<MyContext>(options =>
    {
        options.UseInMemoryDatabase("MyContext", InMemoryDatabaseRoot);
        options.UseInternalServiceProvider(serviceProvider);
     });
     services.AddDbContext<MySecondContext>(options =>
     {
        options.UseInMemoryDatabase("MyContext", InMemoryDatabaseRoot);
        options.UseInternalServiceProvider(serviceProvider);
      });
