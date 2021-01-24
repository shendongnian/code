    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
        public virtual Wallet Wallet { get; set; }
    
    }
    
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }
    
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
        public DbSet<Wallet> Wallets { get; set; }
        public DbSet<UserStock> UserStocks { get; set; }
    
    }
