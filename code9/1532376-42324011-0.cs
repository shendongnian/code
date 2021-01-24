    public static T FirstIfOnlyOne<T>(this IEnumerable<T> source, T defaultValue = default(T))
    {
        // (Null check and IList<T> optimization omitted...)
        using (IEnumerator<T> enumerator = source.GetEnumerator())
        {
            if (enumerator.MoveNext()) // Is there at least one item?
            {
                T item = enumerator.Current; // Save it.
                if (!enumerator.MoveNext()) // Is that it?
                    return item;
            }
        }
        return defaultValue;
    }
