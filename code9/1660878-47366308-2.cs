    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder); // MUST go first.
        modelBuilder.HasDefaultSchema("YOUR_SCHEMA"); // Use uppercase!
        modelBuilder.Entity<ApplicationUser>().ToTable("AspNetUsers");
        modelBuilder.Entity<IdentityRole>().ToTable("AspNetRoles");
        modelBuilder.Entity<IdentityUserRole>().ToTable("AspNetUserRoles");
        modelBuilder.Entity<IdentityUserClaim>().ToTable("AspNetUserClaims");
        modelBuilder.Entity<IdentityUserLogin>().ToTable("AspNetUserLogins");
    }
