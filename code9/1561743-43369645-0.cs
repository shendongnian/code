    public void Test<T,TKey>(IQueryable<T> collection, Expression<Func<T,TKey>> orderByExpr)
    {
        // your logic here 
        // ...
        collection = collection.OrderByDescending(orderByExpr);
    }
