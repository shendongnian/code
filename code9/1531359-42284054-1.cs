    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        modelBuilding.Entity<User>()
            .HasMany(r => r.Roles)
            .WithMany(u => u.Users)
            .Map(ru =>
            {
                ru.ToTable("User_Role_XREF", "dbo");
                ru.MapLeftKey("User_ID");
                ru.MapRightKey("Role_ID");
            });
    }
