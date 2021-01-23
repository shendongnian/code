    public static class TimeZoneConversion
    {
    	public static System.DateTime FromSpecificTimeZoneToUTC(string specificZone, System.DateTime specificTimeZoneDateTime)
    	{
    		TimeZoneInfo fromZone = TimeZoneInfo.FindSystemTimeZoneById(specificZone);
    		return TimeZoneInfo.ConvertTimeToUtc(specificTimeZoneDateTime, fromZone);
    	}
    	//--------------------------------------------------------------------------------------------
    	public static System.DateTime FromSpecificTimeZoneToUTC(TimeZoneInfo fromZone, System.DateTime specificTimeZoneDateTime)
    	{
    		System.DateTime temp = System.DateTime.SpecifyKind(specificTimeZoneDateTime, DateTimeKind.Unspecified);
    		return TimeZoneInfo.ConvertTimeToUtc(temp, fromZone);
    	}
    	//--------------------------------------------------------------------------------------------
    	public static System.DateTime FromUTCToSpecificTimeZone(TimeZoneInfo toZone, System.DateTime UTCTimeZoneDateTime)
    	{
    		return TimeZoneInfo.ConvertTimeFromUtc(UTCTimeZoneDateTime, toZone);
    	}
    	//--------------------------------------------------------------------------------------------
    	public static TimeSpan GetTimeZoneOffsetDifference(TimeZoneInfo oldZone, TimeZoneInfo newZone)
    	{
    		var now = DateTimeOffset.UtcNow;
    		TimeSpan oldOffset = oldZone.GetUtcOffset(now);
    		TimeSpan newOffset = newZone.GetUtcOffset(now);
    		TimeSpan difference = oldOffset - newOffset;
    		return difference;
    	}
    	//--------------------------------------------------------------------------------------------
    	public static System.DateTime FromUTCToSpecificTimeZone(string totimezone, System.DateTime UTCTimeZoneDateTime)
    	{
    		TimeZoneInfo toZone = TimeZoneInfo.FindSystemTimeZoneById(totimezone);
    		return TimeZoneInfo.ConvertTimeFromUtc(UTCTimeZoneDateTime, toZone);
    	}
    	//--------------------------------------------------------------------------------------------
    	public static System.DateTime FromLocalTimeZoneToUTC(System.DateTime localDateTime)
    	{
    		return localDateTime.ToUniversalTime();
    	}
    	//--------------------------------------------------------------------------------------------
    	public static string GetServerTimeZoneID()
    	{
    		return TimeZone localZone = TimeZone.CurrentTimeZone.StandardName;
    	}
    	//--------------------------------------------------------------------------------------------
    
    }
