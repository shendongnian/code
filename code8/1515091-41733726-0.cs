    string s = "g";
	string[] color = { "greena", "browna", "bluea" };
	var query = color.Where(c => c.Contains(s));
	Console.WriteLine(query.Count());
	var b = "a";
	query = query.Where(c => c.Contains(b));
    Console.WriteLine(query.Count()); // <-- This is where the entire expression is evaluated
