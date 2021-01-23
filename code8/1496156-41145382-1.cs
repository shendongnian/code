    public abstract class GenericRepository<T, TEntityKey> : IGenericRepository<T, TEntityKey>
        where T : EntityBase<TEntityKey>
    {
        protected IDbContext _entities;
        protected readonly IDbSet<T> _dbset;
    
        protected GenericRepository()
        {
            _entities = new MyDbContext();
            _dbset = _entities.Set<T>();
        }
    
        ...
    }
