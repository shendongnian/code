    private static async Task<int> TestAwait()
    {
        await Task.Delay(1000);
        return 0;
    }
    private static Task Test()
    {
        return Task.Delay(1000);
    }
