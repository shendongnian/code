    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        modelBuilder.Types()
         .Where(x => typeof(ModificationHistory) != x && typeof(ModificationHistory).IsAssignableFrom(x))
         .Configure(x => x.Property("UserName").HasMaxLength(256));
    }
