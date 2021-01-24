    //On input  { "", "a", "", "c", "f", "b", "", "e", "d" }
    //On output { "", "a", "", "b", "c", "d", "", "e", "f" }
	public static List<string> Sort(List<string> l)
	{
		var filtered = l
			.Select((s, i) => new { i, s })
			.Where(o => !string.IsNullOrEmpty(o.s))
			.OrderBy(o => o.s)
			.ToArray();
		var indexed = filtered
			.Select(o => o.i)
			.OrderBy(i => i)
			.Select((n, i) => new { n, filtered[i].s })
			.ToArray();
		return l
			.Select((s, i) =>
			{
				if (string.IsNullOrEmpty(s))
					return s;
				return indexed.First(o => o.n == i).s;
			})
			.ToList();
	}
