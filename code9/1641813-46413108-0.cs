    public static List<TTarget> ToList<TSource, TTarget>(
        this IEnumerable<TSource> source,
        Func<TSource, TTarget> conversion)
    {
        if (source == null)
            throw new ArgumentNullException(nameof(source));
        if (conversion == null)
            throw new ArgumentNullException(nameof(conversion));
        return source.Select(conversion).ToList();
    }
