    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyAllConfigurationsFromAssembly(GetType().Assembly);           
        base.OnModelCreating(modelBuilder);
    }
