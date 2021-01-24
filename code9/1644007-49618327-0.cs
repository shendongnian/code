    public class MyContext: IdentityDbContext<ApplicationUser>
    {
        public DbSet<ApplicationUser> Users { get; set; }
        public DbSet<BlobResource> BlobResources { get; set; }
    }
