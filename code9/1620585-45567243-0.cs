    public static void ThreadMethod(object o)
    {
        var limit = o is string ? Int32.Parse((string)o) : (int)o;
        for (int i = 0; i < limit; i++)
        {
            Console.WriteLine("ThreadProc: {0}", i);
            Thread.Sleep(0);
        }
    }
