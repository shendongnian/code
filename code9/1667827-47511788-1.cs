    public class Repository<TEntity, TPrimaryKey> where TEntity: IEntity<TPrimaryKey>
    {
        protected readonly DbContext _dbContext;
        protected readonly DbSet<T> _dbEntitySet;
    
        public Repository(InteractiveChoicesContext dbContext)
        {
            _dbContext = dbContext;
            _dbEntitySet = dbContext.Set<T>();
        }
    }
