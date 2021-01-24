    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ISoftDeletable>().HasQueryFilter(e => !e.IsDeleted);
     
        base.OnModelCreating(modelBuilder);
    }
