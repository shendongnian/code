	private DateTime GetNextDate(DateTime dt, int DesiredDay)
	{
		if (DesiredDay >= 1 && DesiredDay <= 31)
		{
			do
			{
				dt = dt.AddDays(1);
			} while (dt.Day != DesiredDay);
			return dt.Date;
		}
		else
		{
			throw new ArgumentOutOfRangeException();
		}     
	}
