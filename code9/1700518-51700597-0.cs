    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<MyDBContext>
    {
        public MyDBContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            var builder = new DbContextOptionsBuilder<MyDBContext>();
            var connectionString = configuration.GetConnectionString("migrationContextConnection");
            builder.UseSqlServer(connectionString);
            return new MyDBContext(builder.Options);
        }
    }
