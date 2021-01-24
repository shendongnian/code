	public static void Main()
	{
		var i = new TaggableInteger(1047483640);
		Console.WriteLine("{0} {1}", i.IsTagged, i.Value);
		i.IsTagged = true;
		Console.WriteLine("{0} {1}", i.IsTagged, i.Value);
		i.IsTagged = false;
		Console.WriteLine("{0} {1}", i.IsTagged, i.Value);
	}
