     public class EFRepository<T, K> : IRepository<T, K>, IDisposable where T : class
        {
            protected readonly DbContext _dbContext;
            private readonly DbSet<T> _entitySet;
    
            public EFRepository(DbContext context)
            {
                _dbContext = context;
                _entitySet = _dbContext.Set<T>();
            }
    
            public T Add(T item)
            {
                item = _entitySet.Add(item);
                _dbContext.SaveChanges();
                return item;
            }
    
            public bool Update(T item)
            {
                _entitySet.Attach(item);
                _dbContext.Entry(item).State = EntityState.Modified;
                _dbContext.SaveChanges();
                return true;
            }
    
            public bool DeleteById(K id)
            {
                var item = _entitySet.Find(id);
                _entitySet.Remove(item);
                _dbContext.SaveChanges();
                return true;
            }
    }
