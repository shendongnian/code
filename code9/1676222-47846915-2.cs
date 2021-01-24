    // value types should be excluded as they can't be null
    // hence the "where T : class" clause
    internal static void ThrowIfNull<T>(this T obj, String parameterName) where T : class
    {
        if (obj == null)
            throw new ArgumentNullException(parameterName);
    }
