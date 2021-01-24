    ExecuteEvery(action, 5000).Wait();
    private static async Task ExecuteEvery(Action action, int milliseconds)
    {
        while (true)
        {
            await Task.Delay(milliseconds);
            action();
        }
    }
