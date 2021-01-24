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
