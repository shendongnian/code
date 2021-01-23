    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Parent>().Property(p => p.MyValueObj).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        base.OnModelCreating(modelBuilder);
    } 
