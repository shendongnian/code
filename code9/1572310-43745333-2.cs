    public static class TimeUtils
    {
    	static readonly TimeSpan DayStart = new TimeSpan(0, 0, 0);
    	static readonly TimeSpan DayEnd = new TimeSpan(24, 0, 0);
    	public static TimeSpan Intersect(TimeSpan startA, TimeSpan endA, TimeSpan startB, TimeSpan endB)
    	{
    		if (startA < endA)
    		{
    			if (startB < endB)
    				return IntersectCore(startA, endA, startB, endB);
    			else
    				return IntersectCore(startA, endA, startB, DayEnd)
    					+ IntersectCore(startA, endA, DayStart, endB);
    		}
    		else
    		{
    			if (startB < endB)
    				return IntersectCore(startA, DayEnd, startB, endB)
    					+ IntersectCore(DayStart, endA, startB, endB);
    			else
    				return IntersectCore(startA, DayEnd, startB, DayEnd)
    					+ IntersectCore(startA, DayEnd, DayStart, endB)
    					+ IntersectCore(DayStart, endA, startB, DayEnd)
    					+ IntersectCore(DayStart, endA, DayStart, endB);
    		}
    	}
    	private static TimeSpan IntersectCore(TimeSpan startA, TimeSpan endA, TimeSpan startB, TimeSpan endB)
    	{
    		return Max(Min(endA, endB) - Max(startA, startB), TimeSpan.Zero);
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
