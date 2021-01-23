    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<User>(entity => {
            entity.HasIndex(e => e.Email).IsUnique();
        });
    }
