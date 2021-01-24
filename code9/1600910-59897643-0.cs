public IQueryable CreateQuery(Expression expression)
{
    switch (expression)
    {
        case MethodCallExpression m:
            {
                var resultType = m.Method.ReturnType; // it shoud be IQueryable<T>
                var tElement = resultType.GetGenericArguments()[0];
                var queryType = typeof(TestDbAsyncEnumerable<>).MakeGenericType(tElement);
                return (IQueryable)Activator.CreateInstance(queryType, expression);
            }
    }
    return new TestDbAsyncEnumerable<TEntity>(expression);
}
public IQueryable<TElement> CreateQuery<TElement>(Expression expression)
{
    var queryType = typeof(TestDbAsyncEnumerable<>).MakeGenericType(typeof(TElement));
    return (IQueryable<TElement>)Activator.CreateInstance(queryType, expression);
}
It works fine with the latest EF6 as of today.
