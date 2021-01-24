    public class MyDbContext : DbContext
    {
        public DbSet<Request> Requests { get; set; }
        public DbSet<Position> Positions { get; set; }
    
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"...");
        }
    
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Position>().HasMany(x => x.StartPositionRequests).WithOne(x => x.StartPosition).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Position>().HasMany(x => x.DestinationPositionRequests).WithOne(x => x.DestinationPosition).OnDelete(DeleteBehavior.Restrict);
        }
    }
