    public IQueryable<TElement> CreateQuery<TElement>(Expression expression)
    {
        var queryType = typeof(TestDbAsyncEnumerable<>).MakeGenericType(typeof(TElement));
        return (IQueryable<TElement>)Activator.CreateInstance(queryType, expression);
    }
