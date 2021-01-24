	public static void Main()
	{
		Console.WriteLine("Marshall! Hello.");
		Console.WriteLine(Reverse("Marshall! Hello."));
		
	}
	
	public static bool IsLettersOrDigits(string s)
	{
		foreach (var c in s)
		{
			if (!char.IsLetterOrDigit(c))
			{
				return false;
			}
		}
		return true;
	}
	
	public static string Reverse(char[] s)
	{
    	Array.Reverse(s);
    	return new string(s);
	}
	
	
	public static string Reverse(string source)
	{
		var parts = Regex.Split(source, @"([^a-zA-Z0-9])");
		
		var results = new List<string>();
		foreach(var x in parts)
		{
			results.Add(IsLettersOrDigits(x)
					   ? Reverse(x.ToCharArray())
					   : x);
		}
		return string.Concat(results);
	}
