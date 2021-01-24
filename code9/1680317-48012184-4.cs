    public class GenericRepository<TEntity, TKey> : IRepository<TEntity, TKey>
        where TEntity : class, IEntity<TKey> {
        private readonly IDbContext dbContext;
        public GenericRepository(IAppDbContext dbContext) {
            this.dbContext = dbContext;
        }
        //...code removed for brevity
    }
