    public static IEnumerable<TSource> SkipAndInclude<TSource>(this IEnumerable<TSource> source, int count, Func<TSource, bool> predicate)
    {
        if (source == null) throw new ArgumentNullException(nameof(source));
        if (predicate == null) throw new ArgumentNullException(nameof(predicate));
    
        using (IEnumerator<TSource> e = source.GetEnumerator())
        {
            while (count > 0 && e.MoveNext())
            {
                if (!predicate(e.Current)) count--;
            }
            if (count <= 0)
            {
                while (e.MoveNext()) yield return e.Current;
            }
        }
    }
    
    public static IEnumerable<TSource> TakeAndInclude<TSource>(this IEnumerable<TSource> source, int count, Func<TSource, bool> predicate)
    {
        if (source == null) throw new ArgumentNullException(nameof(source));
        if (predicate == null) throw new ArgumentNullException(nameof(predicate));
    
        if (count > 0)
        {
            foreach (TSource element in source)
            {
                yield return element;
                if (!predicate(element)) count--;
                if (count == 0) break;
            }
        }
    }
