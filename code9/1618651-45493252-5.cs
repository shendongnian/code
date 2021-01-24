    static T AddAll<T>(IEnumerable<T> src, Func<T, T, T> adder = null) {
        // Declare Parameter Expressions
        ParameterExpression paramA = Expression.Parameter(typeof(T), "valueA"),
            paramB = Expression.Parameter(typeof(T), "valueB");
        // add the parameters together
        BinaryExpression body;
        if (adder == null)
            body = Expression.Add(paramA, paramB);
        else
            body = Expression.Add(paramA, paramB, adder.GetMethodInfo());
        // Compile it
        Func<T, T, T> add = Expression.Lambda<Func<T, T, T>>(body, paramA, paramB).Compile();
        // Call it
        return src.Aggregate(default(T), (ans, n) => add(ans, n));
    }
