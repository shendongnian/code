    var s = "abc({";
	var results = Regex.Split(s, @"(\()")
        .Where(m=>!string.IsNullOrEmpty(m))
        .ToList();
	Console.WriteLine(string.Join(", ", results));
    // => abc, (, {
