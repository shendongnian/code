    int seconds = totalSeconds % 60;
    int totalMinutes = totalSeconds / 60;
    int minutes = totalMinutes % 60;
    int totalHours = totalMinutes / 60;
    int hours = totalHours % 24;
    int totalDays = totalHours / 24;
    if (totalDays > 0)
    {
        Console.Write(totalDays + " Days ");
    }
    if (totalHours > 0)
    {
        Console.Write(hours + " Hours ");
    }
    if (totalMinutes > 0)
    {
        Console.Write(minutes + " Minutes ");
    }
    Console.WriteLine(seconds + " Seconds");
