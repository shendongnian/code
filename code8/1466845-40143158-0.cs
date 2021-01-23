	var sorter = new Dictionary<int, string>()
	{
		{ 1, "c" },
		{ 2, "a" },
		{ 3, "b" },
		{ 4, "c" },
		{ 5, "c" },
		{ 6, "a" },
		{ 7, "a" },
		{ 8, "b" },
		{ 9, "d" },
		{ 10, "c" },
	};
	
	empList =
		empList
			.OrderBy(e => sorter.ContainsKey(e.Id) ? sorter[e.Id] : "z")
			.ToList();
