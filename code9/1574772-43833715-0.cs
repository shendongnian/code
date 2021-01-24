    public class MyDbContext : DbContext
    {
        public DbSet<Artists> Artists{ get; set; }
    
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Artists>.HasKey(x => x.ArtistId);
            base.OnModelCreating(modelBuilder);
        }
    }
