    using System;
    using System.Diagnostics;
    using System.Threading;
    using System.Threading.Tasks;
    namespace ConsoleApp1
    {
        class Program
        {
            static void Main()
            {
                var counter1 = new PerformanceCounter(".NET CLR LocksAndThreads", "Contention Rate / sec",  "ConsoleApp1");
                var counter2 = new PerformanceCounter(".NET CLR LocksAndThreads", "Total # of Contentions", "ConsoleApp1");
                Task.Run(() => test());
                Task.Run(() => test());
                Task.Run(() => test());
                Task.Run(() => test());
                while (true)
                {
                    Thread.Sleep(100);
                    Console.WriteLine($"Contention: {counter1.NextValue()}/sec, Total: {counter2.NextValue()}");
                }
            }
            static object locker = new object();
            static void test()
            {
                while (true)
                {
                    lock (locker)
                    {
                        Thread.Sleep(50);
                    }
                }
            }
        }
    }
