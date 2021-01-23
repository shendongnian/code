    public class NhQueryProviderProxy<T> : INhQueryProvider
    {
        private readonly IQueryable<T> _data;
        public NhQueryProviderProxy(IQueryable<T> data)
        {
            _data = data;
        }
        // These two CreateQuery methods get called by LINQ extension methods to build up the query
        // and by ToFuture to return a queried collection and allow us to apply more filters
        public IQueryable CreateQuery(Expression expression)
        {
            Type elementType = TypeSystem.GetElementType(expression.Type);
            return (IQueryable)Activator.CreateInstance(typeof(NHibernateQueryableProxy<>)
                                        .MakeGenericType(elementType), new object[] { this, expression });
        }
        public IQueryable<TElement> CreateQuery<TElement>(Expression expression)
        {
            return new NHibernateQueryableProxy<TElement>(this, expression);
        }
        // Those two Execute methods are called by terminal methods like .ToList() and .ToArray()
        public object Execute(Expression expression)
        {
            return ExecuteInMemoryQuery(expression, false);
        }
        public TResult Execute<TResult>(Expression expression)
        {
            bool IsEnumerable = typeof(TResult).Name == "IEnumerable`1";
            return (TResult)ExecuteInMemoryQuery(expression, IsEnumerable);
        }
        public object ExecuteFuture(Expression expression)
        {
            // Here we need to return a NhQueryProviderProxy so we can add more queries
            // to the queryable and use another ToFuture if desired
            return CreateQuery(expression);
        }
        private object ExecuteInMemoryQuery(Expression expression, bool isEnumerable)
        {
            var newExpr = new ExpressionTreeModifier<T>(_data).Visit(expression);
            if (isEnumerable)
            {
                return _data.Provider.CreateQuery(newExpr);
            }
            return _data.Provider.Execute(newExpr);
        }
        public void SetResultTransformerAndAdditionalCriteria(IQuery query, NhLinqExpression nhExpression, IDictionary<string, Tuple<object, IType>> parameters)
        {
            throw new NotImplementedException();
        }
    }
