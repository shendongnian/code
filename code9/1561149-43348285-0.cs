    public static IQueryable<T> Apply<T>(IQueryable<T> collection) {
        var propertyName = "Name";
        var searchValue = "Boris";
        // we have parameter "c"
        var selectorParameter = Expression.Parameter(typeof(T), "c");
        // constant "Boris"
        var searchTermExpression = Expression.Constant(searchValue);
        // "c.Name"
        var selector = Expression.PropertyOrField(selectorParameter, propertyName);
        // "c.Name == "Boris"
        var equal = Expression.Equal(selector, searchTermExpression);
        // c => c.Name == "Boris"
        var where = Expression.Lambda<Func<T, bool>>(equal, selectorParameter);
        return collection.Where(where);
    }
