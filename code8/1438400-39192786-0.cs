    using System.Collections.Async;
    static async Task DoWithRetries(Func<Task> action, int retryCount, string method)
    {
        while (true)
        {
            try
            {
                await action();
                break;
            }
            catch (Exception e)
            {
                LoggerAgent.LogException(e, method);
            }
            if (retryCount <= 0)
                break;
            retryCount--;
            await Task.Delay(millisecondsDelay: 200);
        };
    }
    
    static async Task Example()
    {
        List<int> ints = new List<int>();
        for (int i = 0; i < 1000; i++)
            ints.Add(i);
        Func<int, Task> actionOnItem =
            async item =>
            {
                await DoWithRetries(async () =>
                {
                    List<string> test = await fetchSmthFromDb();
                    Console.WriteLine("#" + item + "  " + test[0]);
                    if (test[0] != "test")
                        throw new InvalidOperationException("unexpected result"); // will be re-tried
                },
                retryCount: 5,
                method: "test");
            };
        await ints.ParallelForEachAsync(actionOnItem, maxDegreeOfParalellism: 100);
    }
