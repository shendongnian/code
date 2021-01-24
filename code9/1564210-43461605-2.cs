	string date = "10/06/2017 1:30:00 PM"; // UTC time
	var dateValue = DateTime.ParseExact(date, "d/MM/yyyy h:mm:ss tt", CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal);
	
	string timeZone = "Eastern Standard Time"; // Offset is -5 hours
	
	TimeZoneInfo newTimeZone = TimeZoneInfo.FindSystemTimeZoneById(timeZone);
	Console.WriteLine(newTimeZone.BaseUtcOffset); // -5
	Console.WriteLine(newTimeZone.IsDaylightSavingTime(dateValue)); // True
	
	var result = TimeZoneInfo.ConvertTime(dateValue, newTimeZone);
	Console.WriteLine(result);
