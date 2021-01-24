    public static class QueryableExtensions
    {
        public IQueryable<TEntity> GetAll(IQueryable<TEntity> queryable, Expression<Func<TEntity, bool>> predicate)
        {
            return queryable.Where(predicate);
        }
    }
    // usage
    IGenericRepository repository = ...;
    var stockTransation = repository.Set<Product>()
        .GetAll(p => p.product == product && p.warehouse == warehouse)
        .Take(5) 
        .ToArray();
