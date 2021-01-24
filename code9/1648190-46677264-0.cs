    class Program
    {
        private static void PrintMessage()
        {
            Console.WriteLine("Hello Task library!");
        }
        
        static async Task Main()
        {
            var task = new Task(PrintMessage);
            task.Start();
            await task;
        }
    }
