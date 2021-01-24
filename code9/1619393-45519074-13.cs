	public int LoginsByMonth(int year, int month, String username)
	{
		if (month < 1 || month > 12)
		{
			throw new ArgumentOutOfRangeException("month must be between 1 and 12.");
		}
	
		...
		
		DateTime FirstDT = new DateTime(year, month, 1);
		DateTime SecondDT = FirstDT.AddMonths(1).AddSeconds(-1);
	
		...
	}
