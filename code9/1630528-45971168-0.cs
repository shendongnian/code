    var input = "2015/01/22 12:08:51 (GMT-08:00)";
    var format = "yyyy/MM/dd H:mm:ss (zzz)";
    DateTime result;
    // Remove the "GMT" portion of the input
    input = input.Replace("GMT", "");
    if (DateTime.TryParseExact(input, format, CultureInfo.InvariantCulture,
        DateTimeStyles.AdjustToUniversal, out result))
    {
        Console.WriteLine($"'{input}' converts to {result} UTC time.");
    }
    else
    {
        Console.WriteLine($"'{input}' is not in the correct format.");
    }
