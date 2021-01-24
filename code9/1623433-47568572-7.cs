    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions<UserContext> options) : base(options)
        {
            this.Database.EnsureCreated();
        }
        public DbSet<User> Users { get; set; }
    }
