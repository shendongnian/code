    String dtTime = "20161021-13:22:09.974";
    
    DateTime outPut;
    if (DateTime.TryParseExact(dtTime, "yyyyMMdd-HH:mm:ss.fff", null, DateTimeStyles.None, out outPut))
    {
    	var est = TimeZoneInfo.ConvertTimeFromUtc(outPut,
    							TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time"));
    	Console.WriteLine(est);
    }
