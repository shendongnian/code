    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
       modelBuilder.Entity<Organisation>()
            .HasMany(o => o.Users)
            .WithOne(u => u.Organization);
       modelBuilder.Entity<Organisation>()
            .HasOne(o => o.AdminUser);
    }
