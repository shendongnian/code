	string timeZone = "Eastern Standard Time"; // Offset is -5 hours
	
	TimeZoneInfo newTimeZone = TimeZoneInfo.FindSystemTimeZoneById(timeZone);
	Console.WriteLine(newTimeZone.BaseUtcOffset); // -5
	Console.WriteLine(newTimeZone.IsDaylightSavingTime(dateValue)); // True
