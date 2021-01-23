    public class NHibernateQueryableProxy<T> : QueryableBase<T>
    {
        public NHibernateQueryableProxy(IQueryable<T> data) : base(new NhQueryProviderProxy<T>(data))
        {
        }
    
        public NHibernateQueryableProxy(IQueryProvider provider, Expression expression) : base(provider, expression)
        {
        }
    }
