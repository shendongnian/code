    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        modelBuilder.Configurations.AddFromAssembly(typeof(ProductConfiguration).Assembly);
        base.OnModelCreating(modelBuilder);
    }
