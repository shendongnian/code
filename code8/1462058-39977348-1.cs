    protected Expression<Func<Entity, EntityDto>> CustomSelector(Expression<Func<Entity, IQueryable<Entity>>> paramQuery)
    {
    	Expression<Func<Entity, IQueryable<Entity>, EntityDto>> prototype = (e, q) => new EntityDto
    	{
    		Id = e.Id,
    		Name = e.Name,
    		Count = q.Count(),
    	};
    	return Expression.Lambda<Func<Entity, EntityDto>>(
    		prototype.Body
    			.ReplaceParameter(prototype.Parameters[0], paramQuery.Parameters[0])
    			.ReplaceParameter(prototype.Parameters[1], paramQuery.Body),
    		paramQuery.Parameters[0]);
    }
