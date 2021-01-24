    public class YourDbContext : DbContext
    {
        public DbSet<Company> Companies { get; set; }
        public DbSet<Address> Addresses { get; set; }
    
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>()
                .HasOne(p => p.Company)
                .WithMany(b => b.Addresses);
        }
    }
