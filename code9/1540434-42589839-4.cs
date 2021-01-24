    public static class TestingHelpers
    {
    	public static long MsTicks(this int i)
    	{
    		return TimeSpan.FromMilliseconds(i).Ticks;
    	}
    }
