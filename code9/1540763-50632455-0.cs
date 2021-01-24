     public class SalesDbContext : DbContext
    {
        public SalesDbContext(DbContextOptions<SalesDbContext> options) : base(options)
        {
        }
        public DbSet<Domain.Product.Product> Products { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            // Configure database attributes
        }
        
    }
