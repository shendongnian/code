    public class SDbContext : DbContext {
        protected override void OnModelCreating(DbModelBuilder modelBuilder) {
            modelBuilder.Entity<AModel>().ToTable("Table1");
            modelBuilder.Entity<TModel>().ToTable("Table2");
        }
        public DbSet<AModel> A { get; set; }
        public DbSet<TModel> T { get; set; }
    }
