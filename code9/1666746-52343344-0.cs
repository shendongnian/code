    public class AppContextFactory: IDesignTimeDbContextFactory<AppContext>
    {
        public AppContextFactory()
        {
            // A parameter-less constructor is required by the EF Core CLI tools.
        }
        public AppContext CreateDbContext(string[] args)
        {
            var connectionString = Environment.GetEnvironmentVariable("EFCORETOOLSDB");
            if (string.IsNullOrEmpty(connectionString))
                throw new InvalidOperationException("The connection string was not set " +
                "in the 'EFCORETOOLSDB' environment variable.");
             var options = new DbContextOptionsBuilder<AppContext>()
                .UseSqlServer(connectionString)
                .Options;
            return new AppContext(options);
        }
    }
