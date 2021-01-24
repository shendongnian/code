    private static IOrderedQueryable<T> ApplyOrderBy<T>(IQueryable<T> collection, OrderByInfo orderByInfo, Expression<Func<T,int>> nullOrder) {
        ...
        if (!orderByInfo.Initial && collection is IOrderedQueryable<T>) {
            if (orderByInfo.Direction == SortDirection.Ascending)
                methodName = "ThenBy";
            else
                methodName = "ThenByDescending";
        } else {
            if (orderByInfo.Direction == SortDirection.Ascending)
                methodName = "OrderBy";
            else
                methodName = "OrderByDescending";
        }
        if (nullOrder != null) {
            collection = (IQueryable<T>)typeof(Queryable).GetMethods().Single(
                    method => method.Name == methodName
                            && method.IsGenericMethodDefinition
                            && method.GetGenericArguments().Length == 2
                            && method.GetParameters().Length == 2)
                    .MakeGenericMethod(typeof(T), type)
                    .Invoke(null, new object[] { collection, nullOrder });
            // We've inserted the initial order by on nullOrder,
            // so OrderBy on the property becomes a "ThenBy"
            if (orderByInfo.Direction == SortDirection.Ascending)
                methodName = "ThenBy";
            else
                methodName = "ThenByDescending";
        }
        // The rest of the method remains the same
        return (IOrderedQueryable<T>)typeof(Queryable).GetMethods().Single(
                    method => method.Name == methodName
                            && method.IsGenericMethodDefinition
                            && method.GetGenericArguments().Length == 2
                            && method.GetParameters().Length == 2)
                    .MakeGenericMethod(typeof(T), type)
                    .Invoke(null, new object[] { collection, lambda });
    }
