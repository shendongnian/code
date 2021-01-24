    static void Main(string[] args)
    {
        var tokenSource = new CancellationTokenSource();
        var token = tokenSource.Token;
    
        var worker = Task.Run(async () =>
        {
            try
            {
                var task = Task.Run(() => throw new Exception("hi"));
                await task;
            }
            catch (Exception e)
            {
                Console.WriteLine("Async...");
                throw;
            }
    
        }, token);
    
        var main = Task.Run(() =>
        {
            while (!token.IsCancellationRequested)
            {
                Thread.Sleep(1);
            }
        }, token);
    
        var tasks = new[] { worker, main };
        var index = Task.WaitAny(tasks);
    
        var taskThatStopped = tasks[index];
        if (taskThatStopped.IsFaulted)
        {
            Console.WriteLine("Task quit because of a fault");
            Console.WriteLine(taskThatStopped.Exception.InnerException.Message);
        }
        tokenSource.Cancel();
        try
        {
            Task.WaitAll(tasks);
        }
        catch (Exception e)
        {
        }
    }
