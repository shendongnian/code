    private static void Main()
    {
        Console.WriteLine("Starting new task...");
        Task.Run(() =>
        {
            Console.WriteLine(" - Task says 'Hello'");
            Thread.Sleep(TimeSpan.FromSeconds(3));
            Console.WriteLine(" - Task says 'Goodbye'");
        });
        Console.WriteLine("This line should not run twice.");
        Console.WriteLine("Going to sleep while waiting for our task to finish...");
        Thread.Sleep(TimeSpan.FromSeconds(5));
            
        Console.WriteLine("\nDone!\nPress any key to exit...");
        Console.ReadKey();
    }
