    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
       base.OnModelCreating(modelBuilder);
    
       modelBuilder.ApplyConfigurationsFromAssembly(typeof(UserConfiguration).Assembly); // Here UseConfiguration is any IEntityTypeConfiguration
    }
