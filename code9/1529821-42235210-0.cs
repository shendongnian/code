    static void Main(string[] args)
    {
        Console.WriteLine("Starting at " + DateTime.Now.ToString());
        Task.Run(() =>
        {
            Thread.Sleep(10000);
            Console.WriteLine("Done sleeping " + DateTime.Now.ToString());
        });
        Console.WriteLine("Press any Key...");
        Console.ReadKey();
        
    }
