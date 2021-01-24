    if (queries.Count == 0)
        return queryBase.List().First();
    IEnumerable<A> result;
    foreach (var q in queries)
    {
        // Using the IFutureEnumerable directly as an IEnumerable is deprecated.
        result = q.GetEnumerable();
    }
    return result.First();
