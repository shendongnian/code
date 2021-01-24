    services.AddDbContext<CustomerDbContext>(
                    options => options.UseSqlServer(
                        this.Configuration.GetConnectionString("DefaultConnection"),
                        sqlServerOptions => sqlServerOptions.MigrationsHistoryTable("Customer")));
    
    services.AddDbContext<InventoryDbContext>(
                    options => options.UseSqlServer(
                        this.Configuration.GetConnectionString("DefaultConnection"),
                        sqlServerOptions => sqlServerOptions.MigrationsHistoryTable("Inventory")));
