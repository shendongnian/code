    public class ProductContext : DbContext
    {
        public DbSet<Page> Page { get; set; }
        public DbSet<PageBackup> PageBackup { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Page>()
                .Map(m => m.MapInheritedProperties().ToTable("Page"))
                .HasKey(t => t.Id);
            modelBuilder.Entity<PageBackup>()
                .Map(m => m.MapInheritedProperties().ToTable("PageBackUp"))
                .HasKey(t => new { t.PageId, t.Id });
            base.OnModelCreating(modelBuilder);
        }
    }
