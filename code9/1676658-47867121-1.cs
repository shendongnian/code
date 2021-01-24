	public static void Main()
	{
		var scannerInput = "{\"se\":\"NUMBERS\",\"de\":\"NUMBERS\",\"cs\":\"NUMBERS\",\"pc\":\"NUMBERS\",\"nm\":\"NUMBERS\",\"tp\":\"DEL\",\"dt\":\"NUMBERS\",\"tz\":\"UTC+01\",\"dk\":\"\"}";
		var obj = JsonConvert.DeserializeObject<AnObject>(scannerInput);
		
		
		Console.WriteLine(obj.se);
		Console.WriteLine(obj.de);
		Console.WriteLine(obj.cs);
		Console.WriteLine(obj.pc);
	}
