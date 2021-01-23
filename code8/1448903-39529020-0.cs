    public static IEnumerable<T> ReplaceAt<T>(this IEnumerable<T> source, T item, int index)
    {
        int itemIndex = 0;
        using(var iter = source.GetEnumerator())
        {
            while(iter.MoveNext())
            {
                yield return itemIndex++ == index ? item : iter.Current;
            }
        }
    }
