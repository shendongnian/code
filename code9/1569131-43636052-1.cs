    public class ContextDb : DbContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Country>().ToTable("Country");
        }
        public ContextDb() { }
        public DbSet<Country> Country { get; set; }
    }
