    public virtual TEntity GetById(object id, params string[] includeProperties)
    {
    	var propertyName = ((System.Data.Entity.Infrastructure.IObjectContextAdapter)DbContext).ObjectContext
    		.CreateObjectSet<TEntity>().EntitySet.ElementType.KeyMembers.Single().Name;
    
    	var parameter = Expression.Parameter(typeof(TEntity), "e");
    	var predicate = Expression.Lambda<Func<TEntity, bool>>(
    		Expression.Equal(
    			Expression.PropertyOrField(parameter, propertyName),
    			Expression.Constant(id)),
    		parameter);
    
    	var query = DbSet.AsQueryable();
    	if (includeProperties != null && includeProperties.Length > 0)
    		query = includeProperties.Aggregate(query, System.Data.Entity.QueryableExtensions.Include);
    	return query.FirstOrDefault(predicate);
    }
