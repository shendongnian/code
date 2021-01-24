    public static IEnumerable<IEnumerable<T>> Batches<T>(
       this IEnumerable<T> source, int batchSize)
    {
        using(var mover = source.GetEnumerator())
        {
            while (mover.MoveNext())
               yield return LimitMoves(mover, batchSize);
        }
    }
