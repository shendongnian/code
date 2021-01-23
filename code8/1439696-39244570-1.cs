            Task.Run(async () =>
            {
                var tasks = Enumerable.Range(0, 1000000)
                 .Select(i => Console.Out.WriteLineAsync((100000 * 10000).ToString()));
                Debugger.Break();
                await Task.WhenAll(tasks);
            }).GetAwaiter().GetResult();
