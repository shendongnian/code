    public async Task<string> GetStringAsync(int i)
    {
        Task<string> task = new Task<string>(() => GetString(i));
        await task.Start();
        return task;
    }
