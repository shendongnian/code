    static void printTill10()
    {
        while (true)
        {
            lock (locker)
            {
                if (count < 100)
                {
                    count++;
                    Console.WriteLine(string.Format("Thread {0} printed {1}", Thread.CurrentThread.ManagedThreadId.ToString(), count.ToString()));
                }
            }
        }
    }
