    var s = "Hi is this available 18dec to 21st dec 2nd dec 1st jan dec12th";
	var res = Regex.Replace(s, @"(\p{L})?(\d+)(st|[nr]d|th|(\p{L}+))", repl);
	Console.WriteLine(res);
    // => Hi is this available 18 dec to 21st dec 2nd dec 1st jan dec 12th
	
    // This is the callback method that does all the work
	public static string repl(Match m) 
	{
		var res = new StringBuilder();
		res.Append(m.Groups[1].Value);  // Add what was matched in Group 1
		if (m.Groups[1].Success)        // If it matched at all...
			res.Append(" ");            // Append a space to separate word from number
		res.Append(m.Groups[2].Value);  // Add Group 2 value (number)
		if (m.Groups[4].Success)        // If there is a word (not st/th/rd/nd suffix)...
			res.Append(" ");            // Add a space to separate the number from the word
		res.Append(m.Groups[3]);         // Add what was captured in Group 3
		return res.ToString();
	}
