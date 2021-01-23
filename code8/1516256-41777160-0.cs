    modelBuilder.Entity<User>().ToTable("Users");
    modelBuilder.Entity<Role>().ToTable("Roles");
    modelBuilder.Entity<IdentityUserClaim<int>>().ToTable("UserClaims");
    modelBuilder.Entity<IdentityUserRole<int>>().ToTable("UserRoles");
    modelBuilder.Entity<IdentityUserLogin<int>>().ToTable("UserLogins");
    modelBuilder.Entity<IdentityRoleClaim<int>>().ToTable("RoleClaims");
    modelBuilder.Entity<IdentityUserToken<int>>().ToTable("UserToken");
