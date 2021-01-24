    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public CustomerDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
    
            var builder = new DbContextOptionsBuilder<CustomerDbContext>();
            var connectionString = configuration.GetConnectionString("WarehouseConnection");
            builder.UseSqlServer(connectionString);
    
            return new CustomerDbContext(builder.Options);
        }
    }
