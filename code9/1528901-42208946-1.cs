    public static void Main()
	{
		NumberFormatInfo nfi = new CultureInfo("en-US", false).NumberFormat;
        Int64 myInt = 123456789012345;
		
		int[] x = {3,2};
		nfi.NumberGroupSizes = x;
		Console.WriteLine(myInt.ToString("N",nfi));
        //The output will be 12,34,56,78,90,12,345.00
	}
