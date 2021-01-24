    public static IEnumerable<IEnumerable<T>> CreateChunks<T>(this IEnumerable<T> sequence, int chunkLength)
    {
        if (chunkLength < 1)
            throw new ArgumentOutOfRangeException(nameof(chunkLength));
        using (var e = sequence.GetEnumerator())
        {
            while (e.MoveNext())
            {
                yield return createChunk(e, chunkLength);
            }
        }
    }
    private static IEnumerable<T> createChunk<T>(IEnumerator<T> enumerator, int chunkLength)
    {
        var counter = 0;
        do
        {
            yield return enumerator.Current;
            if (++counter == chunkLength)
                break;
        } while (enumerator.MoveNext());
    }
