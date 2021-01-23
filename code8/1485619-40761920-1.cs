    public class ProductContext : DbContext
    {
        public ProductContext()
        {
        }
        public ProductContext(DbContextOptions<ProductContext> options)
            : base(options)
        { }
        public DbSet<Page> Page { get; set; }
        public DbSet<PageBackup> PageBackup { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer("Data Source=.\\sqlexpress;");
            base.OnConfiguring(builder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Page>()
                .HasBaseType<BaseEntity>()
                .ToTable("Page")
                .HasKey(t => t.Id);
            modelBuilder.Entity<PageBackup>()
                .HasBaseType<Page>()
                .HasKey(t => new { t.PageId, t.Id });
            base.OnModelCreating(modelBuilder);
        }
    }
