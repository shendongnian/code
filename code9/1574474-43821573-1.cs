    public static List<WeekOfYear> GetWeeksOfYear(int year)
	{
		var weeksQuantity = GetNumberOfWeeksInYear(year);
		var weeksList = new List<WeekOfYear>();
		for (int i = 1; i <= weeksQuantity; i++)
		{
			var weekNumber = i;
			DateTime firstDay;
			DateTime lastDay;
			GetFirstAndLastDateOfWeek(year, weekNumber, out firstDay, out lasDay);
			weeksList.Add(new WeekOfYear
			{
				FirstDayOfWeek = firstDay,
				LastDayOfWeek  = lastDay,
				WeekNumber = weekNumber
			});
		}
		return weeksList;
	}
	public static int GetNumberOfWeeksInYear(int year)
	{
		var dfi = DateTimeFormatInfo.CurrentInfo;
		var date1 = new DateTime(year, 12, 31);
		if (dfi != null)
		{
			Calendar cal = dfi.Calendar;
			return cal.GetWeekOfYear(date1, dfi.CalendarWeekRule,
				dfi.FirstDayOfWeek);
		}
		return 0;
	}
	public static void GetFirstAndLastDateOfWeek(int year, int weekOfYear, out DateTime firstDay, out DateTime lastDay)
	{
		var ci = CultureInfo.CurrentCulture;
		DateTime jan1 = new DateTime(year, 1, 1);
		int daysOffset = (int)ci.DateTimeFormat.FirstDayOfWeek - (int)jan1.DayOfWeek;
		DateTime firstWeekDay = jan1.AddDays(daysOffset);
		int firstWeek = ci.Calendar.GetWeekOfYear(jan1, ci.DateTimeFormat.CalendarWeekRule, ci.DateTimeFormat.FirstDayOfWeek);
		if ((firstWeek <= 1 || firstWeek >= 52) && daysOffset >= -3)
		{
			weekOfYear -= 1;
		}
		firstDay = firstWeekDay.AddDays(weekOfYear * 7);
		lastDay = firstDay.AddDays(6);
	}
