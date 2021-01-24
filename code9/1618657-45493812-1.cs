    public static T Sum<T>(IEnumerable<T> summands)
    {
        MethodInfo sumMethod;
        if (!_sumMethodsByElementType.TryGetValue(typeof(T), out sumMethod)) throw new InvalidOperationException($"Cannot sum elements of type {typeof(T)}.");
        return (T)sumMethod.Invoke(null, new object[] { summands });
    }
