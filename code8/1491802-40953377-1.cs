	public static void Main()
	{
		var nameLv = "Jevģeņijs";
		var nameEng = "Jevgenijs";
		
		var result = IsEquivalent(nameLv, nameEng);  // returns True
	}
	
	public static bool IsEquivalent(string latvian, string english)
	{
		return english ==
            Encoding.UTF8.GetString(Encoding.GetEncoding("ISO-8859-8").GetBytes(latvian));
	}
