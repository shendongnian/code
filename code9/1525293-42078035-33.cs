    public class SampleContext : DbContext {
        public SampleContext() : base("SampleContext") {}
    
        public DbSet<User> Users { get; set; }
        public DbSet<Sub_User> SubUsers { get; set; }
    }
