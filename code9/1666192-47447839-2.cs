    public static class FloatExtensions
    {
    	public static string Format(this float f, int n)
    	{
    		// return f.ToString($"0.{new String('0', n)}");
    		return f.ToString("0." + new String('0', n));
    	}
    }
    
    rmt.MaxLength = rmt.MinNumber.Format(rmt.Decimal)
