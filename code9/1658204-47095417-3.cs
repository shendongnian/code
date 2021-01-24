    class Program
    {
        static void Main(string[] args)
        {
            var worker = new TaskWorker(1);
            var cts = new CancellationTokenSource();
            var token = cts.Token;
            var tasks = Enumerable.Range(1, 10)
                .Select(e => worker.RunAsync(() => SomeWorkAsync(e, token), token))
                .ToArray();
            Task.WhenAll(tasks).GetAwaiter().GetResult();
        }
        static async Task SomeWorkAsync(int id, CancellationToken cancellationToken)
        {
            Console.WriteLine($"Some Started {id}");
            await Task.Delay(2000, cancellationToken).ConfigureAwait(false);
            Console.WriteLine($"Some Finished {id}");
        }
    }
