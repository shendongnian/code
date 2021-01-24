    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
       modelBuilder.Entity<User>()
            .HasRequired(u => u.Organisation)
            .WithMany(o => o.Users);
       modelBuilder.Entity<Organisation>()
            .HasRequired(o => o.AdminUser);
    }
