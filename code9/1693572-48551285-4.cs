    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
       modelBuilder.Entity<Organisation>()
            .HasMany(o => o.Users)
            .WithOne(u => u.Organisation);
       modelBuilder.Entity<Organisation>()
            .HasOne(o => o.AdminUser)
            .WithOne(u => u.Organisation);
    }
