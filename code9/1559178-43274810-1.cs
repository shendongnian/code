    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    
        modelBuilder.Entity<Users>()
            .MapToStoredProcedures(s => s.Delete(u => u.HasName("DeleteUserById", "dbo")
                                            .Parameter(b => b.id, "userid"))
            );
    }
