        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder); Dont forget to remove
            var user = modelBuilder.Entity<ApplicationUser>().ToTable("Users");
            user.Ignore(u => u.Claims);
            modelBuilder.Entity<IdentityRole>().ToTable("Role");
            var identityUserRole = modelBuilder.Entity<IdentityUserRole>().ToTable("UserRole");
            identityUserRole.HasKey(r => new { r.UserId, r.RoleId });
            var identityUserLogin =  modelBuilder.Entity<IdentityUserLogin>().ToTable("UserLogin");
            identityUserLogin.HasKey(l => new {l.LoginProvider, l.ProviderKey, l.UserId});
            modelBuilder.Ignore<IdentityUserClaim>();
        }
