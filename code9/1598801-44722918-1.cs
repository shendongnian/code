    static void Main(string[] args)
    {
        var clientInput = "14:57";
        var startTime = TimeSpan.Parse(clientInput);
        var currentTime = DateTime.Now.TimeOfDay;
        Console.WriteLine("The start time is: {0}", startTime.ToString("hh\\:mm"));
        Console.WriteLine("The current time is: {0}", currentTime.ToString("hh\\:mm"));
        var difference = currentTime.Subtract(startTime);
        if ((int)difference.TotalMinutes == 0)
        {
            Console.WriteLine("It's time to start!");
        }
        else if ((int)difference.TotalMinutes > 0)
        {
            Console.WriteLine("We should have started {0} minutes ago!",
                (int)difference.TotalMinutes);
        }            
        else
        {
            Console.WriteLine("We will start in: {0} hours and {1} minutes.",
                -difference.Hours, -difference.Minutes);
        }
        Console.Write("\nDone!\nPress any key to exit...");
        Console.ReadKey();
    }
