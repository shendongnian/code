    public class AppDataContext : DbContext
    {
        public AppDataContext(DbContextOptions<AppDataContext> options)
            : base(options)
        {
        }
    
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Mark> Marks { get; set; }
    
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
    
            modelBuilder.Entity<Category>().HasMany(c => c.Marks).WithOne(m => m.Category).HasForeignKey(m => m.CategoryId);
            modelBuilder.Entity<Subject>().HasMany(s => s.Marks).WithOne(m => m.Subject).HasForeignKey(m => m.SubjectId);
            modelBuilder.Entity<Subject>().HasMany(s => s.Categories).WithOne(c => c.Subject).HasForeignKey(c => c.SubjectId);
        }
    }
