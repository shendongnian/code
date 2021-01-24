    private static void Main()
    {
        DateTime sunrise = DateTime.Today.Add(GetTimeFromUser("Enter sunrise time: "));
        DateTime legalStartTime = sunrise.AddMinutes(-30);
        int driveTime = GetIntFromUser(
            "How many minutes will it take to drive to your destination: ");
        int setupTime = GetIntFromUser(
            "How many minutes will it take to set up: ");
        int walkTime = GetIntFromUser(
            "How many minutes will it take to walk from your vehicle to the hunting spot: ");
        int waitTime = GetIntFromUser(
            "Number of minutes between setting up and pulling the trigger: ");
        int totalTime = driveTime + setupTime + walkTime + waitTime;
        DateTime departureTime = legalStartTime.AddMinutes(-totalTime);
        Console.WriteLine($"If sunrise is at {sunrise:hh:mm tt}, and it takes {totalTime} " +
            $"minutes to drive and get ready, you should leave at: {departureTime:hh:mm tt}");
        Console.WriteLine("\nDone!\nPress any key to exit...");
        Console.ReadKey();
    }
