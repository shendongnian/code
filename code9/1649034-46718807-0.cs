    // Remove the parameter-less constructor
    public class ConfigDbContext : DbContext
    {
        public ConfigDbContext(DbContextOptions<ConfigDbContext> options) : base(options)
        { }
        rotected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
