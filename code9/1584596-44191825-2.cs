    class Program
    {
        static void Main(string[] args)
        {
            var mainStart = DateTime.Now;
            var threads = new List<Thread>();
            for (int i = 0; i < 10; i++)
            {
                threads.Add(new Thread(() =>
                {
                    var stepStart = DateTime.Now;
                    Console.WriteLine("{0} Starting {1} on thread {2}...", stepStart, i, Thread.CurrentThread.ManagedThreadId);
                    Thread.Sleep(15000);
                    var stepFinish = DateTime.Now;
                    Console.WriteLine("{0} Finished {1} on thread {2}, duration: {3}",
                        stepStart, i, Thread.CurrentThread.ManagedThreadId, stepFinish - stepStart);
                }));
            }
            foreach (Thread t in threads)
            {
                t.Start(); // Starts all the threads
            }
            foreach(Thread t in threads)
            {
                t.Join(); // Make the main thread wait for the others
            }
            var mainFinish = DateTime.Now;
            Console.WriteLine("{0} Finished, duration {1}", DateTime.Now, mainFinish - mainStart);
            Console.WriteLine("Press any key to exit.");
            Console.Read();
        }
    }
