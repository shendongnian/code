    public class DevOpsDbContext : DbContext
    {
        public DevOpsDbContext(DbContextOptions<DevOpsDbContext> options) : base(options)
        {
        }
    
        public DbSet<NumberTableModel1> _353224061929963 { get; set; }
        public DbSet<NumberTableModel2> _353224061929964 { get; set; }
        public DbSet<NumberTableModel3> _353224061929965 { get; set; }
    
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<NumberTableModel1>().ToTable("353224061929963");
            modelBuilder.Entity<NumberTableModel2>().ToTable("353224061929964");
            modelBuilder.Entity<NumberTableModel3>().ToTable("353224061929965");
        }
    }
