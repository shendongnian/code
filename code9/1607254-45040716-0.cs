	public static int GetMondayCount(int month, int year)
	{
		var date = new DateTime(year, month, 1);
				
		if(date.DayOfWeek != DayOfWeek.Monday)
		{
			int daysUntilMonday = ((int) DayOfWeek.Monday - (int) date.DayOfWeek + 7) % 7;
			date = date.AddDays(daysUntilMonday);
		}
		
		int count = 0;
		
		while(date.Month == month)
		{
			count++;
			date = date.AddDays(7);			
		}
		return count;
	}
