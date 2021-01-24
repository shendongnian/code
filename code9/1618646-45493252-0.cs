    static T AddAll<T>(List<T> src) {
        // Declare Parameter Expressions
        ParameterExpression paramA = Expression.Parameter(typeof(T), "valueA"),
            paramB = Expression.Parameter(typeof(T), "valueB");
        // add the parameters together
        BinaryExpression body = Expression.Add(paramA, paramB);
        // Compile it
        Func<T, T, T> add = Expression.Lambda<Func<T, T, T>>(body, paramA, paramB).Compile();
        // Call it
        return src.Skip(1).Aggregate(src.First(), (ans, n) => add(ans, n));
    }
