    var entities = ChangeTracker.Entries().Where(x => x.Entity is Item && (x.State == EntityState.Added || x.State == EntityState.Modified));
    foreach (var entity in entities)
    {
    	if (entity.State == EntityState.Added)
    	{
    		((BaseEntity)entity.Entity).LastModified = DateTime.UtcNow;
    	}
    }
