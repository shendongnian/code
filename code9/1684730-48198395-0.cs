    class Program
    {
        #region Static fields
        private static volatile bool continueCounting = true;
        #endregion
        #region Methods
        static void Main(string[] args)
        {
            var threadA = new Thread(ThreadA);
            var threadB = new Thread(ThreadB);
            Console.WriteLine(
                "Once you press enter, this application will count as high as it can until you press enter again.");
            var info = Console.ReadKey();
            if (info.Key == ConsoleKey.Enter)
            {
                threadA.Start();
                threadB.Start();
            }
            info = Console.ReadKey();
            if (info.Key == ConsoleKey.Enter)
            {
                continueCounting = false;
            }
            Console.ReadLine();
        }
        static void ThreadA()
        {
            var count = 0;
            for (var i = 0; i < int.MaxValue && continueCounting; i++)
            {
                count++;
            }
            Console.WriteLine($"A: {count}");
        }
        static void ThreadB()
        {
            var count = 0;
            while (continueCounting && count < int.MaxValue)
            {
                count++;
            }
            Console.WriteLine($"B: {count}");
        }
        #endregion
    }
