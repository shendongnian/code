    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.Entity<Models.User>(entity =>
        {
            // Added these two lines
            var index = b.HasIndex(u => new { u.NormalizedUserName }).Metadata; 
            b.Metadata.RemoveIndex(index.Properties);
            entity.HasIndex(a => new { a.NormalizedUserName, a.TenantId }).HasName("UserNameIndex").IsUnique();
        });
    }
