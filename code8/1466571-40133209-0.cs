    public class GenericRepository<TEntity, TId> where TEntity: class, IIdentifyable<TId>
    {
    	protected static Expression<Func<TEntity, bool>> EqualsPredicate(TId id)
    	{
    		Expression<Func<TEntity, TId>> selector = x => x.Id;
    		Expression<Func<TId>> closure = () => id;
    		return Expression.Lambda<Func<TEntity, bool>>(
    			Expression.Equal(selector.Body, Expression.Constant(closure.Body)),
    			selector.Parameters);
    	}
    }
