    using System;
    using System.Collections.Concurrent;
    using System.Threading;
    using System.Threading.Tasks;
    namespace ConsoleApp1
    {
        class Program
        {
            static void Main()
            {
                ParallelOptions po = new ParallelOptions
                {
                    MaxDegreeOfParallelism = 2
                };
                var activeThreads = new ConcurrentDictionary<int, bool>();
                Parallel.For(0, 100, po, x =>
                {
                    activeThreads[Thread.CurrentThread.ManagedThreadId] = true;
                    Console.WriteLine("Active threads: " + string.Join(", ", activeThreads.Keys));
                    Thread.Sleep(200);
                    activeThreads.TryRemove(Thread.CurrentThread.ManagedThreadId, out bool unused);
                });
                Console.ReadLine();
            }
        }
    }
                                            
