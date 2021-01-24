    static T AddAll2<T>(IEnumerable<T> src) {
        // Declare Parameter Expressions
        var paramA = Expression.Parameter(typeof(IEnumerable<T>), "valueA");
        var method = typeof(Enumerable).GetMethods().Where(m => m.Name == "Sum" && m.ReturnType == typeof(double) && !m.IsGenericMethod).Single();
        var body = Expression.Call(method, paramA);
        // Compile it
        Func<IEnumerable<T>, T> sum = Expression.Lambda<Func<IEnumerable<T>, T>>(body, paramA).Compile();
        // Call it
        return sum(src);
    }
