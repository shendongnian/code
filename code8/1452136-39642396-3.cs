    public Task<string> GetStringAsync(int i)
    {
        var tcs = new TaskCompletionSource<string>();
        tcs.SetResult(GetString(i));
        return tcs.Task;
    }
