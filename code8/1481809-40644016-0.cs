    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        // Model Daughter:
        var girlEntity = modelBuilder.Entity<Girl>();
        girlEntity.Map(m =>
        {
            m.MapInheritedProperties();
            m.ToTable("Daughters");
        });
        girlEntity.Property(p => p.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        girlEntity.Property(p => p.Name).IsRequired().HasMaxLength(12);
        girlEntity.Property(p => p.SomeGirlyProperty).IsOptional().HasMaxLength(13);
        // model Boy
        var boyEntity = modelBuilder.Entity<Boy>();
        boyEntity.Map(m =>
        {
            m.MapInheritedProperties();
            m.ToTable("Sons");
        });
        boyEntity.Property(p => p.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        boyEntity.Property(p => p.Name).IsRequired().HasMaxLength(12);
        boyEntity.Property(p => p.SomeBoyishProperty).IsOptional().HasMaxLength(14);
    }
