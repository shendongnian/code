    public static DateTime GetDateExcludeWeekends(DateTime date, int index)
	{
		var newDate = date.AddDays(-index);
		
		if(newDate.DayOfWeek == DayOfWeek.Sunday)
		{
			return newDate.AddDays(-2);
		}
		if(newDate.DayOfWeek == DayOfWeek.Saturday)
		{
			return newDate.AddDays(-1);
		}
		
		return DateTime.Now;
	}
