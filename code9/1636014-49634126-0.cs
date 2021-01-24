    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.Entity<Theme>(b => {
            b.HasKey(x => x.Id);
            b.Property(x => x.Name).IsRequired(true).HasMaxLength(200);
        });
    }
