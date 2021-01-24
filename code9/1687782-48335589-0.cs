    public class CustomRepositoryBase<TEntity, TPrimaryKey> : EfCoreRepositoryBase<CustomDbContext, TEntity, TPrimaryKey>, ICustomRepository<TEntity,TPrimaryKey>
        where TEntity : class, IEntity<TPrimaryKey>
    {
        public CustomRepositoryBase(IDbContextProvider<CustomDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }
        // ...
    }
