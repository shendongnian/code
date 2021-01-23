    class Program
    {
        static void Main(string[] args)
        {
            AsynchronousTask();
            Console.WriteLine("What is your name?");
            var name = Console.ReadLine();
            Console.WriteLine("Hello, {0}", name);
            Console.ReadLine();
        }
        private static async void AsynchronousTask()
        {
            Task.Run(() =>
            {
                while (true)
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("Async tas is running in the background.");
                    Console.ForegroundColor = ConsoleColor.White;
                    Thread.Sleep(1000); //this is just to slowdown background thread
                }
            });
        }
    }
