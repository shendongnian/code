    public static class TimeUtils
    {
    	public static TimeSpan Intersect(TimeSpan startA, TimeSpan endA, TimeSpan startB, TimeSpan endB)
    	{
    		return Max(Min(AdjustEnd(startA, endA), AdjustEnd(startB, endB)) - Max(startA, startB), TimeSpan.Zero);
    	}
    	static readonly TimeSpan DayStart = new TimeSpan(0, 0, 0);
    	static readonly TimeSpan DayEnd = new TimeSpan(24, 0, 0);
    	private static TimeSpan AdjustEnd(TimeSpan start, TimeSpan end)
    	{
    		if (start < DayStart || start >= DayEnd) throw new ArgumentOutOfRangeException("start");
    		if (end < DayStart || end >= DayEnd) throw new ArgumentOutOfRangeException("end");
    		return end >= start ? end : end + DayEnd;
    	}
    	public static TimeSpan Max(TimeSpan a, TimeSpan b)
    	{
    		return a > b ? a : b;
    	}
    	public static TimeSpan Min(TimeSpan a, TimeSpan b)
    	{
    		return a < b ? a : b;
    	}
    }
