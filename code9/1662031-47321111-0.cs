    public class MyDbContext : DbContext {
        private readonly ITenantService _tenantService;
        private int TenantId => TenantService.GetId();
        public DbSet<User> Users { get; set; }
        public MyDbContext(
            DbContextOptions options,
            ITenantService tenantService) {
            _tenantService = tenantService;
        }
        protected override void OnModelCreating(
            ModelBuilder modelBuilder) {
            modelBuilder.Entity<User>().HasQueryFilter(
                u => u.TenantId == TenantId);
        }
    }
