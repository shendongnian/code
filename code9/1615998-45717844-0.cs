    // TODO: Remove.
    // (part of the workaround for https://github.com/aspnet/EntityFramework/issues/5320)
    public class TemporaryDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();
            var builder = new DbContextOptionsBuilder<ApplicationDbContext>();
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            builder.UseSqlServer(connectionString);
            // Stop client query evaluation
            builder.ConfigureWarnings(w => 
                w.Throw(RelationalEventId.QueryClientEvaluationWarning));
            return new ApplicationDbContext(builder.Options);
        }
    }
