    public static CompareValue<T1, T2> CreateComparer<T1, T2>(List<CompareColumns> columns)
    {
        var propertyNames = columns.Select(x => x.Columns).ToList();
        var param1 = Expression.Parameter(typeof (T1), "val1");
        var param2 = Expression.Parameter(typeof (T2), "val2");
        var expressionBody =
            propertyNames
                .Select(propertyName =>
                    Expression.Equal(
                        Expression.Property(param1, propertyName),
                        Expression.Property(param2, propertyName)))
                .Aggregate(Expression.AndAlso);
        return
            Expression
                .Lambda<CompareValue<T1, T2>>(
                    expressionBody,
                    param1,
                    param2)
                .Compile();
    }
