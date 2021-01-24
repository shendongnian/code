	public static void Main()
	{
		var str ="Hellooooo".PadRight(50)+"Test";
        str += Environment.NewLine + ("World").PadRight(50)+"Test";
        str += Environment.NewLine + ("Hello Worldoooooooo").PadRight(50)+"Test";
        Console.WriteLine(str);
	}
