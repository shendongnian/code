    public abstract class QueryableEntityBase<TEntity> : IQueryable<TEntity> where TEntity : class
    {
        protected QueryableEntityBase(DbContext context)
        {
            Context = context ?? throw new ArgumentNullException(nameof(context));
            Queryable = context.Set<TEntity>().AsQueryable();
        }
        public Type ElementType => Queryable.ElementType;
        public Expression Expression => Queryable.Expression;
        public IQueryProvider Provider => Queryable.Provider;
        protected IQueryable<TEntity> Queryable { get; }
        private DbContext Context { get; }
        public IEnumerator<TEntity> GetEnumerator() => Queryable.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => Queryable.GetEnumerator();
    }
    // You need to create this per entity you want to be injectable
    public class MyQueryableEntity : QueryableEntityBase<MyEntity>
    {
        public MyQueryableEntity(ApplicationDbContext context) : base(context) { }
    }
