    public static IEnumerable<T> Peek<T>(this IEnumerable<T> source, Action<T> action)
    {
        using (var iterator = source.GetEnumerator())
        {
            while (iterator.MoveNext())
            {
                action(iterator.Current);
            }
        }
        using (var iterator = source.GetEnumerator())
        {
            while (iterator.MoveNext())
            {
                yield return iterator.Current;
            }
        }
    }
