    namespace ConsoleApplication10
    {
        class Program
        {
            static void Main(string[] args)
            {
                new Thread(Go).Start();
                Console.WriteLine("Main thread {0} exiting", Environment.CurrentManagedThreadId);
            }
    
            private static void Go()
            {
                var thread = Thread.CurrentThread;
                Console.WriteLine("{0} thread {1} sleeping",thread.IsBackground ? "Background" : "Foreground",  thread.ManagedThreadId);
                Thread.Sleep(100000);
    
            }
        }
    }
