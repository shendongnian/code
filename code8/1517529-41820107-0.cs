	private DateTime ConvertToLocalTime(string datetimestring)
	{
	    DateTime timeUtc = DateTimeOffset.Parse(datetimestring).UtcDateTime;
	    TimeZoneInfo cstZone = TimeZoneInfo.FindSystemTimeZoneById("Central Standard Time");
	    DateTime cstTime = TimeZoneInfo.ConvertTimeFromUtc(timeUtc, cstZone);
	    return cstTime;
	}
