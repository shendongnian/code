    public static bool StartsWith<T>(this IEnumerable<T> source, IEnumerable<T> prefix, IEqualityComparer<T> comparer = null)
    {
        if (source == null)
        {
            throw new ArgumentNullException(nameof(source));
        }
        if (prefix == null)
        {
            throw new ArgumentNullException(nameof(prefix));
        }
        comparer = comparer ?? EqualityComparer<T>.Default;
        using (var sourceEnumerator = source.GetEnumerator())
        using (var prefixEnumerator = prefix.GetEnumerator())
        {
            while (true)
            {
                if (!sourceEnumerator.MoveNext())
                {
                    return !prefixEnumerator.MoveNext();
                }
                if (!prefixEnumerator.MoveNext())
                {
                    return true;
                }
                if (!comparer.Equals(sourceEnumerator.Current, prefixEnumerator.Current))
                {
                    return false;
                }
            }
        }
    }
