    class Program
    {
        private static object _lock = new Object();
        static void Main(string[] args)
        {
            Random random = new Random(DateTime.Now.Second);
            
            int[] startOrders = new int[10];
            for (int i = 0; i < startOrders.Length; i++)
            {
                startOrders[i] = i;
            }
            //shuffle the array
            for (int i = startOrders.Length - 1; i >= 0; i--)
            {
                int j = random.Next(0, i);
                int temp = startOrders[i];
                startOrders[i] = startOrders[j];
                startOrders[j] = temp;
            }
            Thread[] threads = new Thread[startOrders.Length];
            for (int i = 0; i < startOrders.Length; i++)
            {
                threads[i] = new Thread(ThreadProc)
                                 {
                                     Name = $"#{startOrders[i]}"
                                     
                                 };
            }
            Parallel.ForEach(threads, thread => thread.Start());
            
            Console.ReadLine();
        }
        static void ThreadProc()
        {
            // simulates there are 10 tasks needs to do.
            for (int i = 0; i < 10; i++)
            {
                lock (_lock)
                {
                    Debug.Print(
                        $"Thread {Thread.CurrentThread.Name} acquired the lock and is working for task #{i}");
                    // simulates a work.
                    Thread.Sleep(5);
                }
            }
        }
    }
