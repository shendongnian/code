    var strs = new List<string>() { "Boy has a dog and a cat.", 
			"Boy something a gerbil.",
			"Sally owns a cat." };
	foreach (var s in strs)
	{
		var results = Regex.Matches(s, @"(?<=^Boy\b.*?)\b(?:dog|cat|gerbil)\b")
		        .Cast<Match>()
		        .Select(m => m.Value)
		        .ToList();
	     if (results.Count > 0) {
			Console.WriteLine("{0}:\n[{1}]\n------", s, string.Join(", ", results));
	     }
	     else
	     {
	     	Console.WriteLine("{0}:\nNO MATCH!\n------", s);
	     }
	}
