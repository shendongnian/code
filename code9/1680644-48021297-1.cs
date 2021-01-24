    [Obsolete("Do not use with IEnumerable!", true)]
    public static T Foo<T>(this IEnumerable current) where T : class, new()
    {
        ...
    }
