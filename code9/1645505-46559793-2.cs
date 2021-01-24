    public static class Extensions
    {
    	public static string ToTrimmendString(this decimal num)
    	{
		    if (num % 1 == 0)
    		{
	    		return num.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture);
    		}
    		return num.ToString().TrimEnd('0');
    	}
    }
