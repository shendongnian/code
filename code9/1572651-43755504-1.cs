    public static IEnumerable<int> FindIndexes<T>(this IEnumerable<T> items, Func<T, bool> predicate)
    {
        int index = 0;
        foreach (T item in items)
        {
            if (predicate(item))
            {
                yield return index;
            }
            index++;
        }
    }
