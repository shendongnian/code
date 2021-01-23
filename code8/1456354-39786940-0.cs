        string time = Console.ReadLine();
        DateTime outValue = DateTime.MinValue;
        if (time.Length == 6)
           time = "0" + time;
        bool error = DateTime.TryParseExact(time, "HH:mmtt" /*"hh:mmtt"*/, CultureInfo.InvariantCulture, DateTimeStyles.None, out outValue);
        Console.WriteLine(error);
        Console.WriteLine(outValue);
        Console.Read();
