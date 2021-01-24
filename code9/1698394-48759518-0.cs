    services.AddDbContext<CustomerDbContext>(options =>
      options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")),
      x => x.MigrationsHistoryTable("CustomerDbContext"));
    
    services.AddDbContext<InventoryDbContext>(options =>
      options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")),
      x => x.MigrationsHistoryTable("InventoryDbContext"));
