    static Mutex mut;
    static void Main(string[] args)
    {
        bool createdNew;
        mut = new Mutex(true, "Global\\test", out createdNew);
        if (createdNew) {
            Console.WriteLine("New instance created with initially owned = true");
        }
        else if (IsInstance())
        {
            Console.WriteLine("New Instance created...");
        }
        else
        {
            Console.WriteLine("Instance already acquired...");
        }
        if (createdNew)
        {
            Thread.Sleep(500);
            mut.ReleaseMutex();
        }
        Console.ReadLine();
        
    }
    static bool IsInstance()
    {
        if (!mut.WaitOne(0))
        {
            Console.WriteLine("Thread id {0} Waiting at Mutex...", AppDomain.GetCurrentThreadId());
            return false;
        }
        else
        {
            Console.WriteLine("Thread id {0} got Mutex...", AppDomain.GetCurrentThreadId());
            Thread.Sleep(500);
            mut.ReleaseMutex();            
            return true;
        }
    }
