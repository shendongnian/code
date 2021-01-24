    public class QueryableEntityBase<TContext, TEntity> : IContextSetQueryable<TDbContext, TEntity>, IQueryable<TEntity> where TEntity : class, TContext : DbContext
    {
        private TContext Context { get; }
        protected QueryableEntityBase(TContext context)
        {
            Context = context ?? throw new ArgumentNullException(nameof(context));
            Queryable = context.Set<TEntity>().AsQueryable();
        }
    }
