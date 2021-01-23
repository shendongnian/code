	public static void Main()
	{
		var str = "1.0";
		
		decimal result = Convert(str, ConvertToDecimal);
	}
	
	public static decimal ConvertToDecimal(string str)
	{
		return decimal.Parse(str);
	}
	
	public static TOut Convert<TIn, TOut>(TIn item, Func<TIn, TOut> f)
	{
		return f(item);
	}
