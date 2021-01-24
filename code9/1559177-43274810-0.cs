    protected override void OnModelCreating(DbModelBuilder modelBuilder) // this method wroite after getting error
    {
        modelBuilder.Entity<IdentityUserLogin>().HasKey<string>(l => l.UserId);
        modelBuilder.Entity<IdentityRole>().HasKey<string>(r => r.Id);
        modelBuilder.Entity<IdentityUserRole>().HasKey(r => new { r.RoleId, r.UserId });
    
        modelBuilder.Entity<Users>()
            .MapToStoredProcedures(s => s.Delete(u => u.HasName("DeleteUserById", "dbo")
                                            .Parameter(b => b.id, "userid"))
            );
    }
