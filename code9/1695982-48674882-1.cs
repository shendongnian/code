    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        ((Model)modelBuilder.Model).ConventionDispatcher.StartBatch();
        foreach (var entityType in modelBuilder.Model.GetEntityTypes())
        foreach (var index in entityType.GetIndexes().ToList())
            if (index.DeclaringEntityType.Name.Contains("Junctions"))
                entityType.RemoveIndex(index.Properties);
    }
