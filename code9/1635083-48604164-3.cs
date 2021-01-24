    public class Test: FullAuditedEntity
    {
        // PK
        [MaxLength(NVarcharLength14), DataType(DataType.Text)]
        public virtual string Code { get; set; }
    
        // Unique constraint
        public int MyUniqueId { get; set; }
    }
    
    public class AbpProjectNameDbContext : AbpZeroDbContext<Tenant, Role, User, AbpProjectNameDbContext>
    {
        /* Define a DbSet for each entity of the application */    
        public DbSet<Test> Tests { get; set; }
        
        public AbpProjectNameDbContext(DbContextOptions<AbpProjectNameDbContext> options) : base(options) {}
    
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
    
            modelBuilder.Entity<Test>().Property(t => t.Id).ValueGeneratedOnAdd(); // Auto-increment
            modelBuilder.Entity<Test>().HasAlternateKey(t => t.Id);                // Auto-increment, closed-wont-fix: https://github.com/aspnet/EntityFrameworkCore/issues/7380
            modelBuilder.Entity<Test>().HasKey(t => t.Code);                       // PK
            modelBuilder.Entity<Test>().HasIndex(t => t.MyUniqueId).IsUnique();    // Unique constraint
        }
    }
