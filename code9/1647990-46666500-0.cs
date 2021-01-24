    var s = "Hi is this available 18dec to 21st dec 2nd dec 1st jan dec12th";
	var res = Regex.Replace(s, @"(\p{L})?(\d+)(st|[nr]d|th|(\p{L}+))", repl);
	Console.WriteLine(res);
	
    // This is the callback method that does all the work
	public static string repl(Match m) 
	{
		var res = new StringBuilder();
		res.Append(m.Groups[1].Value);
		if (m.Groups[1].Success)
			res.Append(" "); 
		res.Append(m.Groups[2].Value);
		if (m.Groups[4].Success)
			res.Append(" ");
		res.Append(m.Groups[3]);
		return res.ToString();
	}
