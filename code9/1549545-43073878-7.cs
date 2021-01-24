    if (queries.Count == 0)
        return queryBase.List().First();
    List<A> result;
    foreach (var q in queries)
    {
        // Using the IFutureEnumerable directly as an IEnumerable is deprecated.
        result = q.GetEnumerable()
            // Due to a bug, GetEnumerable is not yet enough to trigger execution.
            .ToList();
    }
    return result.First();
