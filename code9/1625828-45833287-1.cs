    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<CodingBlastDbContext>
    {
        public CodingBlastDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            var builder = new DbContextOptionsBuilder<CodingBlastDbContext>();
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            builder.UseSqlServer(connectionString);
            return new CodingBlastDbContext(builder.Options);
        }
    }
