    public static IEnumerable<IEnumerable<T>> Batches<T>(
       this IEnumerable<T> source, int batchSize)
    {
        for (var mover = source.GetEnumerator(); ;)
        {
            if (!mover.MoveNext()) // there is no items for next batch
                yield break;
            else
                yield return LimitMoves(mover, batchSize);
        }
    }
    private static IEnumerable<T> LimitMoves<T>(IEnumerator<T> mover, int limit)
    {
        // if you are here then there is an item which you can yield
        do
        {
            yield return mover.Current;
        }
        while (--limit > 0 && mover.MoveNext());
    }
