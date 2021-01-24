        var dt = TimeZoneInfo.ConvertTime(DateTime.Now, TimeZoneInfo.FindSystemTimeZoneById("E. Africa Standard Time"));
        // Get C# time in milliseconds (since 1900-01-01)
        double milli = new TimeSpan(dt.Ticks).TotalMilliseconds;
        // Get Unix timestamp
        double unix = dt.Subtract(new DateTime(1970, 1, 1)).TotalMilliseconds;
        Console.WriteLine("Total Milliseconds: {0}  Unix: {1}", milli, unix);
