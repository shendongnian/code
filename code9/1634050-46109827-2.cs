    Console.WriteLine($"The current time is {DateTime.Now.ToString("hh\\:mm\\:ss")}.");
    var currentTime = DateTime.Now.TimeOfDay;
    var start = new TimeSpan(20, 0, 0);
    var end = new TimeSpan(8, 0, 0);
    var midnight = new TimeSpan(24, 0, 0);
    if (currentTime >= start || currentTime <= end)
    {
        var hoursLeftUntil8 = currentTime.Hours >= 20
            ? midnight.Subtract(DateTime.Now.TimeOfDay).Add(end)
            : end.Subtract(DateTime.Now.TimeOfDay);
        Console.WriteLine("There are {0} hours, {1} minutes, and {2} seconds left until 8AM",
            hoursLeftUntil8.Hours, hoursLeftUntil8.Minutes, hoursLeftUntil8.Seconds);
    }
    else
    {
        Console.WriteLine("It is not between 8PM and 8AM.");
    }
    Console.WriteLine("\nDone!\n\nPress any key to exit...");
    Console.ReadKey();
