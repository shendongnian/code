    foreach (var entityType in modelBuilder.Model.GetEntityTypes())
    {
    	if (typeof(EntityMinimum).IsAssignableFrom(entityType.ClrType))
    		entityType.FindProperty("Version").IsConcurrencyToken = false;
    }
