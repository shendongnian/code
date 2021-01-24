    var txt = @"John Doe    000115   \nWilson Chan 000386\nTye Owens   000589\nJames Peter 000211\nCarl Spade  000445\nSally Doe   000213";
	var splits = txt.Split('\n') // Split into lines 
		.Select(m => new KeyValuePair<string,string>(m.Substring(15,2), m)) // Create key value pairs
		.GroupBy(z => z.Key)   // Group by the 2-char substring
		.Where(y => y.Count() > 1);  // Grab only those with the same key
	foreach (var x in splits)        // Display the groups
	{
		Console.WriteLine("--- {0} ---", x.Key);
		foreach (var y in x)
			Console.WriteLine(y.Value);
	}
