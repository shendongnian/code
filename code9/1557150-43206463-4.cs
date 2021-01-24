    public interface IGenericRepository
    {
        IQueryable<TEntity> Set<TEntity>();
    }
    public class EntityFrameworkRepository : IGenericRepository
    {  
        // ...
        public IQueryable<TEntity> Set<TEntity>()
        {
            return _context.Set<TEntity>();
        }
    }
    // usage
    IGenericRepository repository = ...;
    var stockTransation = repository.Set<Product>()
        .Where(p => p.product == product && p.warehouse == warehouse)
        .Take(5)
        .ToArray();
