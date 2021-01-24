    var stopwatch = new Stopwatch();
    while (true)
    {
        Console.WriteLine("tap 'y' to start,'n' to stop,'q' to quit.");
        switch (Console.ReadLine())
        {
            case "y":
                Console.WriteLine("start");
                // Resets *and* starts if necessary
                stopwatch.Restart();
                break;
            case "n":
                Console.WriteLine("stop");
                stopwatch.Stop();
                Console.WriteLine(stopWatch.Elapsed);
                break;
            case "q":
                return;
        }
    }
