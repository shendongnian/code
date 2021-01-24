    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        modelBuilder.Conventions.Add(new OracleConventions.AllCapsTableAndColumnConvention());
        modelBuilder.Conventions.Add(new OracleConventions.AllCapsForeignKeyConvention());
        base.OnModelCreating(modelBuilder);
    }
