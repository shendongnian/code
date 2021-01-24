    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Threading;
    using System.Threading.Tasks;
    
    class Program
    {
        static void Main(string[] args)
        {
            ThreadPool.SetMinThreads(50000, 50000);
            var tasks = Enumerable.Repeat(0, 100000)
                .Select(_ => Task.Run(IoBoundWork))
                .ToArray();
            Task.WaitAll(tasks);
            var maxTime = tasks.Max(t => t.Result);
            Console.WriteLine($"Max: {maxTime}");
        }
    
        private static async Task<double> IoBoundWork()
        {
            var sw = Stopwatch.StartNew();
            await Task.Delay(1000);
            return sw.Elapsed.TotalSeconds;
        }
    }
