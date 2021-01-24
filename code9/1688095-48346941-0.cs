    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var parameters = new object[] { modelBuilder };
        foreach (var entityType in modelBuilder.Model.GetEntityTypes())
        {
            var method = entityType.ClrType.GetMethod("OnModelCreating", BindingFlags.Static | BindingFlags.NonPublic);
            if (method != null)
                method.Invoke(null, parameters);
        }
    }
