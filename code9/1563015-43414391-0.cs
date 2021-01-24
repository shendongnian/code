	public static void Main()
	{
		var input = "[[:de:Hello World]]";
		var output = Regex.Replace(input, @"(\[\[:de:)(.+)(\]\])",  m => "{{de|" +  m.Groups[2].Value + "}}");
		Console.WriteLine(output);
	}
