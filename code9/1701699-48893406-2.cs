	public static class ExtensionMethods
	{
		static public double TotalMinutes(this IEnumerable<TimeSheetLog> input, DateTime startPeriod, DateTime endPeriod)
		{
			return TimeSpan.FromTicks
			(
				input
				.Where( a=>
    				a.ClockOutTimeStamp >= startPeriod &&
	    			a.ClockInTimeStamp <= endPeriod
				)
				.Select( a=>
					Math.Min(a.ClockOutTimeStamp.Ticks, endPeriod.Ticks) - 
					Math.Max(a.ClockInTimeStamp.Ticks, startPeriod.Ticks)
				)
				.Sum()
			)
			.TotalMinutes;
		}
	}
