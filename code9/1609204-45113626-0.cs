    public static IEnumerable<Task<T>> EnumerateWithDelay<T>(Func<int, T> generator, Func<int, T, bool> limiter, TimeSpan delay)
    {
        var idx = 0;
        while (true)
        {
            var item = generator(idx);
            if (!limiter(idx, item)) yield break;
            yield return Task.Delay(delay).ContinueWith(_ => item);
            idx++;
        }
    }
    public async Task A()
    {
        foreach (var itemTask in EnumerateWithDelay(idx => idx, (idx, val) => idx < 10, TimeSpan.FromSeconds(0.5)))
        {
            // I'll take .5 seconds
            var number = await itemTask;
        }
    }
