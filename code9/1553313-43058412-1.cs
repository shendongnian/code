    public class Thing<TEntity>
    {
    	public IQueryable<TEntity> EntitySet = new TEntity[0].AsQueryable();
    	public List<T> FilterPagerGroup<T, TType>(
    		Expression<Func<TEntity, bool>> where,
    		Expression<Func<IGrouping<TType, TEntity>, T>> select, int skip, int take,
    		Expression<Func<IGrouping<TType, TEntity>, TType>> orderBy,
    		Expression<Func<TEntity, TType>> groupBy)
    	{
    		List<T> result;
    
    		result = EntitySet.Where(where).GroupBy(groupBy).OrderBy(orderBy).Skip(skip).Take(take).Select(select).ToList();
    
    		return result;
    	}
    }
