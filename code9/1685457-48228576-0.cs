    public static bool IsValidDouble(string ValueToTest)
	{
	    return double.TryParse(ValueToTest, out double d) && 
               !(double.IsNaN(d) || double.IsInfinity(d));
    }
