    public Task<string> GetStringAsync(int i)
    {
        Task<string> task = new Task<string>(() => GetString(i));
        task.Start();
        return task;
    }
