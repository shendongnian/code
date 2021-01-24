    public static bool HasExactlyOneElement<T>(this IEnumerable<T> source)
    {
        using (var enumerator = source.GetEnumerator())
            return enumerator.MoveNext() && !enumerator.MoveNext();
    }
