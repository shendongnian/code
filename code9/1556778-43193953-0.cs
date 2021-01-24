    private static readonly SemaphoreSlim Semaphore = new SemaphoreSlim(1);
    private static async Task<WebResponse> GetThrottledWebResponse(WebRequest request)
    {
        await Semaphore.WaitAsync().ConfigureAwait(false);
        try
        {
            return await request.GetResponseAsync().ConfigureAwait(false);
        }
        finally
        {
            Semaphore.Release();
        }
    }
