    /// <summary>
    /// Enumerates a collection in parallel and calls an async method on each item. Useful for making 
    /// parallel async calls, e.g. independent web requests when the degree of parallelism needs to be
    /// limited.
    /// </summary>
    public static Task ForEachAsync<T>(this IEnumerable<T> source, int degreeOfParalellism, Func<T, Task> action)
    {
        return Task.WhenAll(Partitioner.Create(source).GetPartitions(degreeOfParalellism).Select(partition => Task.Run(async () =>
        {
            using (partition)
                while (partition.MoveNext())
                    await action(partition.Current);
        })));
    }
