    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        modelBuilder.Types().Where(x => typeof(Base) != x && typeof(Base).IsAssignableFrom(x))
            .Configure(x => x.Property("UserName").HasMaxLength(256));
    }
