    public class ApiDbContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyAllConfigurationsFromCurrentAssembly("MyRoot.Api.Entities.Configuration");
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
    }
