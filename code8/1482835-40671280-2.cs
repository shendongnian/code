    void Main()
    {
    	var currentDate = DateTimeOffset.Now.ToUniversalTime();
    	var convertedTime = ConvertUtcToEasternStandard(currentDate);
    	
    	var format = "yyyy-MM-ddTHH:m:sszzz";
    	Console.WriteLine(currentDate.ToString(format));
    	Console.WriteLine(convertedTime.ToString(format));
    }
    
    // Define other methods and classes here
    private static DateTimeOffset ConvertUtcToEasternStandard(DateTimeOffset dateTime)
    {
    	var easternZone = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");
    	return TimeZoneInfo.ConvertTime(dateTime, easternZone);
    }
