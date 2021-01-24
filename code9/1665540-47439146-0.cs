    public static IEnumerable<TSource> SkipAndInclude<TSource>(this IEnumerable<TSource> source, int count, Func<TSource, bool> include)
    {
        using (IEnumerator<TSource> iterator = source.GetEnumerator())
        {
            for (int i = 0; i < count; i++)
            {
                if (!iterator.MoveNext())
                {
                    yield break;
                }
    
                if (include(iterator.Current))
                {
                    yield return iterator.Current;
                }
            }
            while (iterator.MoveNext())
            {
                yield return iterator.Current;
            }
        }
    }
    
    public static IEnumerable<TSource> TakeAndInclude<TSource>(this IEnumerable<TSource> source, int count, Func<TSource, bool> include)
    {
        using (IEnumerator<TSource> iterator = source.GetEnumerator())
        {
            for (int i = 0; i < count && iterator.MoveNext(); i++)
            {
                if (include(iterator.Current))
                {
                    count++;
                }
    
                yield return iterator.Current;
            }
        }
    }
