    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<ApplicationUser>().Ignore(c => c.EmailConfirmed)
                                           .Ignore(c => c.PhoneNumber)
                                           .Ignore(c => c.PhoneNumberConfirmed)
                                           .Ignore(c => c.TwoFactorEnabled)
                                           .Ignore(c => c.LockoutEnabled)
                                           .Ignore(c => c.LockoutEndDateUtc);
        modelBuilder.Entity<ApplicationUser>().ToTable("Users");
    }
