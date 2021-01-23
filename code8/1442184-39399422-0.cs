    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        var entityMethod = typeof(DbModelBuilder).GetMethod("Entity");
        foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
        {
            var entityTypes = assembly
              .GetTypes()
              .Where(t =>
                t.GetCustomAttributes(typeof(PersistentAttribute), inherit: true)
                .Any());
            foreach (var type in entityTypes)
            {
                entityMethod.MakeGenericMethod(type)
                  .Invoke(modelBuilder, new object[] { });
            }
        }
        base.OnModelCreating(modelBuilder);
    }
