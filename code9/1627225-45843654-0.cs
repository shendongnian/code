    myTimer = new System.Threading.Timer(timer_Elapsed, null, 0, Timeout.Infinite);
    
    static void timer_Elapsed(object state)
    {
        Thread.Sleep(100);
        Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
        myTimer.Change(100, Timeout.Infinite);
    }
