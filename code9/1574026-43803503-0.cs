    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<User> Users1 { get; set; }
        public DbSet<User> Users2 { get; set; }
    }
