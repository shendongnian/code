    static void Main(string[] args)
    {
        Console.WriteLine("Stopwatch application");
        Console.WriteLine("tap 'y' to start,'n' to stop,'q' to quit.");
        var stopWatch = new Stopwatch();
        while (true)
        {
            Console.WriteLine("tap 'y' to start,'n' to stop,'q' to quit.");
            var input = Console.ReadLine();
            
            if (input == "y")
            {
                Console.WriteLine("start");
                stopWatch.Start();
            }
            if (input == "n")
            {
                Console.WriteLine("stop");
                TimeSpan temp = stopWatch.Stop();
                Console.WriteLine("{0:D2}:{1:D2}:{2:D2}", temp.Hours, temp.Minutes, temp.Seconds);
            }
            if (input == "q") break;
        }
    }
