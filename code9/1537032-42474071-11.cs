    public static class RxTestingHelpers
    {
    	public static long MsTicks(this int ms)
    	{
    		return TimeSpan.FromMilliseconds(ms).Ticks;
    	}
    
    }
