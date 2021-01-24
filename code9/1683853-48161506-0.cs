    class Program3
    {    
        public static void Main(string[] args)
        {
            Action action = printStuff;    
            ExecuteEvery(action, 5000); // ignore returned task
            //simulate the rest of the application stalling until shutdown events.
            Console.ReadLine();
        }
        private static int x = 0;
        private static void printStuff()
        {
            Console.Error.Write(x++);
        }
        private static async Task ExecuteEvery(Action execute, int milliseconds)
        {
            while (true)
            {
                await Task.Delay(milliseconds);
                execute();
            }
        }
    }
