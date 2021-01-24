    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    
        modelBuilder.Entity<MyEntity>()
          .Property(b => b.MyVersionProperty)
          .IsRowVersion();
    }
