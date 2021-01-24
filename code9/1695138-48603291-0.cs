    class Program
    {
        static void Main(string[] args)
        {
            var scheduler = new EventLoopScheduler(); // will manage thread A
            WriteThreadName();
            scheduler.Schedule(WriteThreadName);
            scheduler.Schedule(() =>
            {
                // inside thread A we create thread B
                new Thread(() =>
                {
                    WriteThreadName();
                    scheduler.Schedule(WriteThreadName); // schedule method on thread A from thread B
                }).Start();
            });
            Console.ReadLine();
            
        }
        static void WriteThreadName()
        {
            Console.WriteLine("Thread: "+Thread.CurrentThread.ManagedThreadId);
        }
    }
