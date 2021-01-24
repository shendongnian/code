    string test1 = "2017-10-04T16:24:55.000-04:00";
    string test2 = "2017-10-04T13:14:35.000+04:00";
    DateTimeOffset dateTime;
    if (DateTimeOffset.TryParse(test1, CultureInfo.InvariantCulture, DateTimeStyles.None, out dateTime))
    {
        Console.WriteLine("Date 1: " + dateTime);
    }
    if (DateTimeOffset.TryParse(test2, CultureInfo.InvariantCulture, DateTimeStyles.None, out dateTime))
    {
        Console.WriteLine("Date 2: " + dateTime);
    }
