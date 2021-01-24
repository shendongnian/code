    static object _locker = new object();
   
    public static void WriteLine (string message)
    {
        lock (_locker)
        {
            Console.WriteLine (message);
        } 
    }
