    public class ApplicationDbContext : DbContext<ApplicationDbContext>
    {
        // DbContext code as normal
    }
    public class ApplicationDbContextFactory : IDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext Create(DbContextFactoryOptions options)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            return new ApplicationDbContext(optionsBuilder.Options);
        }
    }
