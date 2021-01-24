    public abstract class BaseRepository<TEntity>
    {
        protected DbContext context;
    
        protected BaseRepository(MyDbContext context) 
        {
            this.context = context;
        }
    
        public List<TEntity> GetAll() 
        {
            return context.Set<TEntity>().ToList();
        }
    }
