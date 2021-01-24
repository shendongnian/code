    public class CatalogContext : DbContext
    {
        static CatalogContext()
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<CatalogContext>());
        }
        public DbSet<CatalogType> CatalogTypes{ get; set; }
        public DbSet<Catalog> Catalogs{ get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelbuilder.Entity<Catalog>().HasOptional(a=>a.catalogType)
                                .WithMany(au=>au.Catalogs)
                                .HasForeignKey(a=>typeCatalogRefCode);
        }
    }
