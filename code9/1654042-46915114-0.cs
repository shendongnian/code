    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        modelBuilder.Entity<YourEntity>().Property(t => t.YourProperty).IsRequired();
        base.OnModelCreating(modelBuilder);
    }
