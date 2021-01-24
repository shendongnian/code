	public static IEnumerable<DateTime> GetAllDayOfWeekPerMonth(int month, int year, DayOfWeek dayOfWeek)
	{
		var date = new DateTime(year, month, 1);
		
		if(date.DayOfWeek != dayOfWeek)
		{
			int daysUntilDayOfWeek = ((int) dayOfWeek - (int) date.DayOfWeek + 7) % 7;
			date = date.AddDays(daysUntilDayOfWeek);
		}
		
		List<DateTime> days = new List<DateTime>();
		
		while(date.Month == month)
		{
			days.Add(date);
			date = date.AddDays(7);			
		}
		
		return days;
	}
