    public static async Task<IReadOnlyCollection<T>> WhenAll<T>(this IEnumerable<ValueTask<T>> tasks)
    {
        var results = new List<T>();
        var toAwait = new List<Task<T>>();
        foreach (var valueTask in tasks)
        {
            if (valueTask.IsCompletedSuccessfully)
                results.Add(valueTask.Result);
            else
                toAwait.Add(valueTask.AsTask());
        }
        results.AddRange(await Task.WhenAll(toAwait).ConfigureAwait(false));
        return results;
    }
