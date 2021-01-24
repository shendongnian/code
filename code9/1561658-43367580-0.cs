    static IEnumerable<string> GetPrimaryKeyNames<TEntity>(DbContext dbContext)
    	where TEntity : class
    {
    	var entityType = ((System.Data.Entity.Infrastructure.IObjectContextAdapter)dbContext).ObjectContext
    		.CreateObjectSet<TEntity>().EntitySet.ElementType;
    	return entityType.KeyProperties.Select(p => p.Name);
    }
