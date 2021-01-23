     protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                base.OnModelCreating(modelBuilder);
                modelBuilder.Ignore <IdentityUserLogin<string>>();
                modelBuilder.Ignore <IdentityUserRole<string>>();
                modelBuilder.Ignore<IdentityUserClaim<string>>();
                modelBuilder.Ignore<IdentityUserToken<string>>();
                modelBuilder.Ignore<IdentityUser<string>>();
                modelBuilder.Ignore<ApplicationUser>();
