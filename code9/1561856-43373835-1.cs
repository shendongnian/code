	public static void Main()
	{
		Console.WriteLine("Marshall! Hello.");
		Console.WriteLine(Reverse("Marshall! Hello."));
	}
	
	public static string Reverse(string source)
	{
        // we split by groups to keep delimiters
		var parts = Regex.Split(source, @"([^a-zA-Z0-9])");
        // if we got a group of valid characters
		var results = parts.Select(x => x.All(char.IsLetterOrDigit)
                // we reverse it
				? new string(x.Reverse().ToArray())
                // or we keep the delimiters as it
				: x);
        // then we concat all of them
		return string.Concat(results);
	}
