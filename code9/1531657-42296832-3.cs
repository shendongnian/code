    static void Main()
    {
        // Thread-Local variable that yields a name for a thread
        ThreadLocal<string> ThreadName = new ThreadLocal<string>(() =>
        {
            return "Thread" + Thread.CurrentThread.ManagedThreadId;
        });
        // Action that prints out ThreadName for the current thread
        Action action = () =>
        {
            // If ThreadName.IsValueCreated is true, it means that we are not the
            // first action to run on this thread.
            bool repeat = ThreadName.IsValueCreated;            
            Console.WriteLine("ThreadName = {0} {1}", ThreadName.Value, repeat ? "(repeat)" : "");
            Thread.Sleep(1000000);
        };
        int th, io;
        ThreadPool.GetMinThreads(out th, out io);
        Console.WriteLine("cpu:" + Environment.ProcessorCount);
        Console.WriteLine(th);        
        Parallel.Invoke(Enumerable.Repeat(action, 100).ToArray());        
        // Dispose when you are done
        ThreadName.Dispose();
        Console.ReadKey();
    }
