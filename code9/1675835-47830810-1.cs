    public static bool ContainsCountItems<TSource>(this IEnumerable<TSource> source, int count)
    {
        ICollection<TSource> collectionoft = source as ICollection<TSource>;
        if (collectionoft != null) return collectionoft.Count == count;
        ICollection collection = source as ICollection;
        if (collection != null) return collection.Count == count;
        int itemCount = 0;
        using (IEnumerator<TSource> e = source.GetEnumerator())
        {
            checked
            {
                while (e.MoveNext() && ++itemCount <= count)
                {
                    if (itemCount == count)
                        return !e.MoveNext();
                }
            }
        }
        return false;
    }
