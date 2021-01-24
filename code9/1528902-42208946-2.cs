    public static void Main()
	{
		NumberFormatInfo nfi = new CultureInfo("en-IN", false).NumberFormat;
        Int64 myInt = 123456789012345;
		
		Console.WriteLine("NumberGroupSizes.Length : {0}", nfi.NumberGroupSizes.Length);
		for(var i = 0;i<nfi.NumberGroupSizes.Length; i++)
		{
			Console.WriteLine("NumberGroupSizes[{0}] : {1}", i, nfi.NumberGroupSizes[i]);
		}
		Console.WriteLine(myInt.ToString("N",nfi));
