    public class MyDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Image> Images { get; set; }
        public MyDbContext()
            : base("name=MyDbContext")
        {
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Properties<int>().Where(p => p.Name == "Id").Configure(p => p.IsKey());
            modelBuilder.Properties<string>().Configure(p => p.HasMaxLength(100));
            modelBuilder.Entity<Product>().HasRequired(p => p.Brand).WithMany().HasForeignKey(p => p.BrandId);
            modelBuilder.Entity<Product>().HasRequired(p => p.Image).WithMany().HasForeignKey(p => p.ImageId);
            modelBuilder.Entity<Brand>().HasRequired(p => p.Image).WithMany().HasForeignKey(p => p.ImageId);
        }
    }
