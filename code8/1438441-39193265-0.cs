    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    
    class Test
    {
        static void Main()
        {
            var cts = new CancellationTokenSource(TimeSpan.FromSeconds(3));
            var items = Enumerable.Range(0, 100).ToList();
            Parallel.ForEach(items, new ParallelOptions { CancellationToken = cts.Token },
                item =>
                {
                    Console.WriteLine(item);
                    Thread.Sleep(1000);
                });
        }
    }
