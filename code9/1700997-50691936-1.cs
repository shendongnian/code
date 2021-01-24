    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        modelBuilder.Conventions.Add(new FunctionConvention<DbContext>());
        modelBuilder.ComplexType<IdModel>();
        base.OnModelCreating(modelBuilder);
    }
