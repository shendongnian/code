	var list = new string[] { "One", "Two", "Three" };
    var list2 = new string[] { "One", "Five" };
	var db = new string[] { "One", "Two", "Four" };
	var conditions = new List<Func<String, bool>>();
	if (list != null)
	{
		conditions.Add(s => list.Contains(s));
	}
	if (list2 != null)
	{
		conditions.Add(s => list2.Contains(s));
	}
	var query = db.AsEnumerable(); // AsQuerable on your side.
	foreach (var condition in conditions)
	{
		query = query.Where(condition);
	}
	var result = query.ToList(); // Outputs "One".
