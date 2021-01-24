	public static void Main()
	{
		var input = "[[:de:Hello World]]";
        var pattern = @"(\[\[:de:)(.+)(\]\])";
		var output = Regex.Replace(input, pattern, m => "{{de|" +  m.Groups[2].Value + "}}");
		Console.WriteLine(output);
	}
