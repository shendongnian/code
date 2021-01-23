    private static DateTimeOffset ConvertUtcToPacificStandard(DateTimeOffset dateTime)
    {
    	var pacificZone = TimeZoneInfo.FindSystemTimeZoneById("Pacific Standard Time");
    	return TimeZoneInfo.ConvertTime(dateTime, pacificZone);
    }
