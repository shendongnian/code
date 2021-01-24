    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // equivalent of modelBuilder.Conventions.AddFromAssembly(Assembly.GetExecutingAssembly());
        // look at this answer: https://stackoverflow.com/a/43075152/3419825
        // for the other conventions, we do a metadata model loop
        foreach (var entityType in modelBuilder.Model.GetEntityTypes())
        {
            // equivalent of modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            // Add NuGet package "Humanizer" for this to work
            entityType.Relational().TableName = entityType.Relational().TableName.Singularize();
            // equivalent of modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            // and modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            entityType.GetForeignKeys()
                .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade)
                .ToList()
                .ForEach(fk => fk.DeleteBehavior = DeleteBehavior.Restrict);
        }
        base.OnModelCreating(modelBuilder);
    }
