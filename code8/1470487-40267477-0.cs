	List<string> tests = new List<string>()
	{
		"12:23", //Normal
		"2:24", //No trailing 0
		"01:00", //With trailing 0
		"00:21", //00 First number
		"0:32", //0 First Number
		"10:4", //No trailing 0 second number
	};
	foreach (var test in tests)
	{
		TimeSpan t;
		if (TimeSpan.TryParse(test, out t))
			Console.WriteLine(t.TotalMinutes);
		else
			Console.WriteLine("Not valid");
	}
