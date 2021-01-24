    static class Program
    {
        private static int count = 0;
        public static int Count
        {
            get
            {
                return count;
            }
            set
            {
                // Only do something if the value is changing
                if (value != count)
                {
                    DoSomething();
                    count = value;
                }
            }
        }
        private static void DoSomething()
        {
            Console.WriteLine("Doing something!");
        }
        private static void Main()
        {
            Count = 1; // Will 'DoSomething'
            Count = 1; // Will NOT DoSomething since we're not changing the value
            Count = 3; // Will DoSomething
            Console.WriteLine("\nDone!\nPress any key to exit...");
            Console.ReadKey();
        }
    }
