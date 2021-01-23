    public static IEnumerable<IEnumerable<T>> Chunk<T>(this IEnumerable<T> source, int count)
    {
        int c = source.Count();
        int chunksize = c / count + (c % count > 0 ? 1 : 0);
    
        while (source.Any())
        {
            yield return source.Take(chunksize);
            source = source.Skip(chunksize);
        }
    }
