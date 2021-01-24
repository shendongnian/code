    [Obsolete("Do not use with IEnumerable!")]
    public static T Foo<T>(this IEnumerable current) where T : class, new()
    {
        ...
    }
