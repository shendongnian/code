    public abstract class BaseRepository<TEntity> where TEntity : class
    {
        protected DbContext context;
    
        protected BaseRepository(MyDbContext context) 
        {
            this.context = context;
        }
    
        public List<TEntity> GetAll()
        {
            // Set<TEntity> provides you an access to entity DbSet
            // Just like if you call context.Users or context.[AnyTableName]
            return context.Set<TEntity>().ToList();
        }
    }
