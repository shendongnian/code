    private static CancellationTokenSource methodRequests = new CancellationTokenSource();
    private static SemaphoreSlim semaphore = new SemaphoreSlim(1, 1);
    static void Main(string[] args)
    {
        int[] delays = new int[] { 5000, 5010, 5020, 5030, 5040 };
        IEnumerable<Task> tasks = from delay in delays select MethodAsync(delay, new CancellationTokenSource().Token);
        Task.WhenAny(tasks).Wait();
        methodRequests.Cancel();
        ReadKey();
    }
    static async Task MethodAsync(int milliseconds, CancellationToken cancellationToken)
    {
        var methodRequest = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken, methodRequests.Token);
        try
        {
            WriteLine($"waiting semaphore (will wait {milliseconds} ms)");
            await semaphore.WaitAsync(methodRequest.Token);
            WriteLine($"waiting {milliseconds} ms");
            Thread.Sleep(milliseconds);
            WriteLine($"Task finished {milliseconds}");
        }
        catch (OperationCanceledException)
        {
            WriteLine($"Task canceled {milliseconds}");
        }
        finally
        {
            semaphore.Release();
        }
    }
