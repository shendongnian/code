    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Threading.Tasks;
    
    class Program
    {
        static void Main(string[] args)
        {
            var sw = Stopwatch.StartNew();
            var tasks = new List<Task>();
            for (int i = 0; i < 100000; i++)
            {
                tasks.Add(Task.Run(IoBoundWork));
            }
            Task.WaitAll(tasks.ToArray());
            sw.Stop();
            Console.WriteLine(sw.Elapsed);
        }
    
        private static async Task IoBoundWork()
        {
            await Task.Delay(1000);
        }
    }
