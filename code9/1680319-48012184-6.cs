    public class GenericRepository<TEntity, TKey> : IRepository<TEntity, TKey>
        where TEntity : class, IEntity<TKey> {
        private readonly DbContext dbContext;
        public GenericRepository(DbContext dbContext) {
            this.dbContext = dbContext;
        }
        public IEnumerable<TEntity> GetAll() {
            return dbContext.Set<TEntity>().ToList();
        }
    }
