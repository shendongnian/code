    using System;
    using System.Threading;
    using System.Threading.Tasks;
    namespace ConsoleApp4
    {
        class Program
        {
            static void Main()
            {
                Parallel.For(
                    0, // Inclusive start
                    5, // Exclusive end
                    new ParallelOptions{MaxDegreeOfParallelism = 2},
                    i => DoWork(i.ToString()));
            }
            static void DoWork(string workname)
            {
                Thread.Sleep(100);
                Console.WriteLine("--work {0} starts", workname);
                Thread.Sleep(1000);
                Console.WriteLine("--work  {0} finishes", workname);
            }
        }
    }
