	public static DateTime AddMonths(DateTime val, double months)
	{
		double daysInYear = new DateTime(val.Year, 12, 31).DayOfYear;
		double daysInMonth = daysInYear / 12;
			
	    return val.AddDays(months * daysInMonth);
	}
