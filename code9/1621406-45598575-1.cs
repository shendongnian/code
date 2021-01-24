    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        //to fix some conflicts using mysql
        modelBuilder.Entity<ApplicationUser>().Property(u => u.UserName).HasMaxLength(255);
        modelBuilder.Entity<ApplicationUser>().Property(u => u.Email).HasMaxLength(255);
        modelBuilder.Entity<CustomRole>().Property(r => r.Name).HasMaxLength(255);
    }
