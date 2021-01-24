    public static class Extensions
    {
    	public static string ToTrimmendString(this decimal num)
    	{
    		return num.ToString().TrimEnd('0');
    	}
    }
