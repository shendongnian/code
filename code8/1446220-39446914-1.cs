    private static Expression ThrowNotTypeOf(Type type, string paramName)
    {
        var ctor = typeof(ArgumentException).GetConstructor(new[] { typeof(string), typeof(string) });
        Debug.Assert(ctor != null);
        var messageArg = Expression.Constant($"The parameter must be an instance of '{type.Name}'.");
        var paramArg = Expression.Constant(paramName);
        return Expression.Throw(Expression.New(ctor, messageArg, paramArg));
    }
