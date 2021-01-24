    public class PDataContext : DataContext
    {
        public PDataContext() : base()
        {
            Configuration.LazyLoadingEnabled = false;            
            Database.SetInitializer<PDataContext>(null);
        }
        public new DbSet<MyProduct> Products { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Entity<MyProduct>().ToTable("Product");
        }
    }
