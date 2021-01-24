    private static Expression<Func<T, bool>> CreateDynamicSearch<T>(IEnumerable<string> searchableColumns, string[] searchTerms) {
        // start with true, since we combine with AND
        // and true AND anything is the same as just anything
        var predicate = PredicateBuilder.True<T>();
        foreach (var columnName in searchableColumns) {                
            // start with false, because we combine with OR
            // and false OR anything is the same as just anything
            var columnFilter = PredicateBuilder.False<T>();
            foreach (var term in searchTerms) {
                // a =>
                var param = Expression.Parameter(typeof(T), "a");
                // a => a.ColumnName
                var prop = Expression.Property(param, columnName);
                // a => a.ColumnName.Contains(term)
                var call = Expression.Call(prop, "Contains", new Type[0], Expression.Constant(term));
                columnFilter = columnFilter.Or(Expression.Lambda<Func<T, bool>>(call, param));
            }
            predicate = predicate.And(columnFilter);
        }
        return predicate;
    }
