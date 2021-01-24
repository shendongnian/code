    public static void ThreadMethod(object o)
    {
        ThreadMethod(Int32.Parse(o.ToString()));
    }
    public static void ThreadMethod(int o)
    {
        for (int i = 0; i < o; i++)
        {
            Console.WriteLine("ThreadProc: {0}", i);
            Thread.Sleep(0);
        }
    }
