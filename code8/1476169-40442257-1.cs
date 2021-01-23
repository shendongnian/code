    static void Main(string[] args)
    {
        lock (sync) // does nothing (no other treads to lock)
        {
            SafeRun(); // execution
        }
        Console.Write("Safe"); // printing out
    }
    static void SafeRun()
    {
        lock (sync)  // does nothing (no other treads to lock)
        {
               Thread.Sleep(1000); // 1 second pause
        }
    }
