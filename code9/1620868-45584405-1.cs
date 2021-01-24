    class Profile
    {
         ... // profile properties
    }
    // A Follower IS a Profile:
    class Follower : Profile
    {
        public int Id {get; set;}
        ... // Follower properties
    }
    class MyDbContrext : DbContext
    {
        public DbSet<Follower> Followers{get; set;}
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // tell that the Profile base class properties of Follower should be in the
            // Followers table:
            modelBuilder.Entity<Follower>().Map(m =>
            {
                m.MapInheritedProperties();
                m.ToTable(nameof(MyDbContext.Followers));
            });
        }
