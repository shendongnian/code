    public async Task<IEnumerable<T>> FilterAsync<T>(IEnumerable<T> sourceEnumerable, Func<T, Task<bool>> predicateAsync)
    {
        return (await Task.WhenAll(
            sourceEnumerable.Select(
                v => predicateAsync(v)
                .ContinueWith(task => new { Predicate = task.Result, Value = v })))
            ).Where(a => a.Predicate).Select(a => a.Value);
    }
