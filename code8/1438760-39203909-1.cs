    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        modelBuilder.Entity<RSU>().Property(x => x.Length).HasPrecision(6, 2);    
        modelBuilder.Configurations.Add(new RSUConfiguration());
        base.OnModelCreating(modelBuilder);
    }
