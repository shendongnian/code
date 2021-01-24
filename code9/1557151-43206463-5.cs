    public static class QueryableExtensions
    {
        // This one doesn't make much sense, actually
        public static IQueryable<TEntity> GetAll(this IQueryable<TEntity> queryable, Expression<Func<TEntity, bool>> predicate)
        {
            return predicate == null
                ? queryable
                : queryable.Where(predicate);
        }
    }
    // usage
    IGenericRepository repository = ...;
    var stockTransation = repository.Set<Product>()
        .GetAll(p => p.product == product && p.warehouse == warehouse)
        .Take(5) 
        .ToArray();
