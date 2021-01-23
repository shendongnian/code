    DateTime inTime = Convert.ToDateTime("17:19:44"); //example inTime
    DateTime outTime = Convert.ToDateTime("19:19:00"); //example outTime
    TimeSpan span = outTime - inTime;
    TimeSpan duration = span.Duration();
    Console.WriteLine(duration);
