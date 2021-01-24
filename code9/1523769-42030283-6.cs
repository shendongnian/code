    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Ignore<Pet>();
        modelBuilder.Entity<Pet>().HasRequired(p => p.Attributes).WithRequiredDependent(a => a.Owner);
    }
