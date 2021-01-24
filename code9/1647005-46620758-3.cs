    // Enumerable.Contains<byte?>(lst, a.Status)
    var containsCall = Expression.Call(
        typeof(Enumerable), // type
        "Contains", // method
        new Type[] { typeof(byte?) }, // generic type arguments (TSource)
        Expression.Constant(lst),  // arguments (source)
        Expression.PropertyOrField(param, "Status")  // arguments (value)
    );
