    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customizations
        builder.Entity<ApplicationUser>(i =>
        {
            i.ToTable("Users");
            i.HasKey(x => x.Id);
        });
        builder.Entity<ApplicationRole>(i =>
        {
            i.ToTable("Roles");
            i.HasKey(x => x.Id);
        });
        builder.Entity<IdentityUserRole<Guid>>(i =>
        {
            i.ToTable("UserRoles");
            i.HasKey(x => new { x.RoleId, x.UserId });
        });
        builder.Entity<IdentityUserLogin<Guid>>(i =>
        {
            i.ToTable("UserLogins");
            i.HasKey(x => new { x.ProviderKey, x.LoginProvider });
        });
        builder.Entity<IdentityRoleClaim<Guid>>(i =>
        {
            i.ToTable("RoleClaims");
            i.HasKey(x => x.Id);
        });
        builder.Entity<IdentityUserClaim<Guid>>(i =>
        {
            i.ToTable("UserClaims");
            i.HasKey(x => x.Id);
        });
        builder.Entity<IdentityUserToken<Guid>>(i =>
        {
            i.ToTable("UserTokens");
            i.HasKey(x => x.UserId);
        });
    }
