    public class AppContext : HookedDbContext
    {
        public AppContext() : base()
        {
            this.RegisterHook(new TimestampPreInsertHook());
        }
    
        public DbSet<User> Users { get; set; }
        public DbSet<Post> Posts { get; set; }
    }
