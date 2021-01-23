    class Program
    {
        static void Main(string[] args)
        {
            Tracker tracker = new Tracker();
            Console.WriteLine("Main TID: " + Thread.CurrentThread.ManagedThreadId);
            lock (tracker)
            {
                Console.WriteLine("Main Acquired");
                Parallel.Invoke(() => tracker.Method1(),
                    () => tracker.Method2());
            }
        }
    }
    class Tracker
    {
        private int number = 6;
        public void Method1()
        {
            Console.WriteLine("Method1 TID: " + Thread.CurrentThread.ManagedThreadId);
            lock (this)
            {
                Console.WriteLine("Method1 Acquired");
            }
        }
        public void Method2()
        {
            Console.WriteLine("Method2 TID: " + Thread.CurrentThread.ManagedThreadId);
            lock (this)
            {
                Console.WriteLine("Method2 Acquired");
            }
        }
    }
