    public class IdentityContext : DbContext
    {
        public IdentityContext(DbContextOptions<IdentityContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ApplicationUsersConfig());
            modelBuilder.ApplyConfiguration(new AspNetRoleClaimsConfig());
            modelBuilder.ApplyConfiguration(new AspNetRolesConfig());
            modelBuilder.ApplyConfiguration(new AspNetUserClaimsConfig());
            modelBuilder.ApplyConfiguration(new AspNetUserLoginsConfig());
            modelBuilder.ApplyConfiguration(new AspNetUserRolesConfig());
            modelBuilder.ApplyConfiguration(new AspNetUserTokensConfig());
            base.OnModelCreating(modelBuilder);
        }
    } 
