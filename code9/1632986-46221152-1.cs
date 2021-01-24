    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Types<TypeEntity>().Configure(c =>
        {
            c.HasKey(p => p.Key);
            // probably not needed, but won't do any harm
            c.Property(p => p.Key).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            c.ToTable(c.ClrType.Name);
        });
    }
