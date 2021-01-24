    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.Entity<ApplicationUser>()
            .HasMany(e => e.UserRoles)
            .WithOne()
            .HasForeignKey(e => e.UserId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<ApplicationUserRole>()
            .HasOne(e => e.User)
            .WithMany(e => e.UserRoles)
            .HasForeignKey(e => e.UserId);
        builder.Entity<ApplicationUserRole>()
            .HasOne(e => e.Role)
            .WithMany(e => e.UserRoles)
            .HasForeignKey(e => e.RoleId);
    }
