    Console.WriteLine($"The current time is {DateTime.Now.TimeOfDay.ToString("hh\\:mm\\:ss")}.");
    var currentHour = DateTime.Now.TimeOfDay.Hours;
    if (currentHour >= 20 || currentHour <= 8)
    {
        var hoursLeftUntil8 = currentHour >= 20
            ? new TimeSpan(24, 0, 0).Subtract(DateTime.Now.TimeOfDay).Add(new TimeSpan(8, 0, 0))
            : new TimeSpan(8, 0, 0).Subtract(DateTime.Now.TimeOfDay);
        Console.WriteLine("There are {0} hours, {1} minutes, and {2} seconds left until 8AM",
            hoursLeftUntil8.Hours, hoursLeftUntil8.Minutes, hoursLeftUntil8.Seconds);
    }
    else
    {
        Console.WriteLine("It is not between 8PM and 8AM.");
    }
    Console.WriteLine("\nDone!\n\nPress any key to exit...");
    Console.ReadKey();
