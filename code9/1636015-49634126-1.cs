    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        var themeEntity = builder.Entity<Theme>();
        themeEntity.HasKey(x => x.Id);
        themeEntity.Property(x => x.Name)
            .HasMaxLength(200)
            .IsRequired(true);
    }
