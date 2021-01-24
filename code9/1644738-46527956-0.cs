	public static void Main()
	{
		dynamic x = "foo";
		
		Test(x);
		
		x = 34;
		
		Test(x);
	}
	
	public static void Test(string s)
	{
		Console.WriteLine("String " + s);
	}
	public static void Test(int n)
	{
		Console.WriteLine("Int " + n);
	}
