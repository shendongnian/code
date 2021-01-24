    public class AppIdentityDbContext : IdentityDbContext<AppUser, AppRole, Guid, AppUserClaim, AppUserRole,
        AppUserLogin, AppRoleClaim, AppUserToken>
    {
        public AppIdentityDbContext(DbContextOptions<AppIdentityDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<AppUser>().ToTable("User");
            builder.Entity<AppRole>().ToTable("Role");
            builder.Entity<AppUserRole>().ToTable("UserRole");
            builder.Entity<AppUserClaim>().ToTable("UserClaim");
            builder.Entity<AppRoleClaim>().ToTable("RoleClaim");
            builder.Entity<AppUserLogin>().ToTable("UserLogin");
            builder.Entity<AppUserToken>().ToTable("UserToken");
        }
    }
