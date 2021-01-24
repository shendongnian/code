    private static int count = 0;
    private static ManualResetEvent finish = new ManualResetEvent(false);
    private static int stopValue = 7;
    private static int syncInterval = 0; //0ms
    private static object lockObject = new object();
    static void Main(string[] args)
    {
        Thread t0 = new Thread(() => Counter(1, 10));
        Thread t1 = new Thread(() => Counter(10, 20));
        t0.Name = "Thread 1";
        t1.Name = "Thread 2";
        t0.Start();
        t1.Start();
        t0.Join();
        t1.Join();
        Console.ReadKey();
    }
    public static void Counter(int k, int m)
    {
        for (int i = k; i < m; i++)
        {
            lock (lockObject)
            {
                if (finish.WaitOne(syncInterval))
                    break;
                count++;
                Console.WriteLine($"{count} {i}");
                if (count == stopValue)
                {
                    finish.Set();
                }
            }
        }
    }
