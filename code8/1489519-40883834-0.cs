        public partial class ODMSDBContext : DbContext
        {
            public ODMSDBContext() : base("name=ODMSConnection") { }
        
            public virtual DbSet<Vendor> Vendor { get; set; }
            public virtual DbSet<Brand> Brand { get; set; }
        
            protected override void OnModelCreating(DbModelBuilder modelBuilder)
            {
                modelBuilder.Entity<Brand>()
                    .Property(e => e.ExtraCode)
                    .IsUnicode(false);
        
                modelBuilder.Entity<Brand>()
                    .Property(e => e.Name)
                    .IsUnicode(false);
        
                modelBuilder.Entity<Brand>()
                    .HasMany(e => e.SubBrand)
                    .WithRequired(e => e.Brand)
                    .HasForeignKey(e=>e.ID)
                    .WillCascadeOnDelete(false);
        
                modelBuilder.Entity<Vendor>()
                    .Property(e => e.Name)
                    .IsUnicode(false);
        
                modelBuilder.Entity<Vendor>()
                    .HasMany(e => e.Brand)
                    .WithRequired(e => e.Vendor)
                    .HasForeignKey(e=>e.ID)
                    .WillCascadeOnDelete(false);
            }
        }
