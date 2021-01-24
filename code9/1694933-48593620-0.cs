	void Main()
	{
	    var keyList = new List<int>() {0, 1, 2};
	    var newList = new List<int>() {1, 2, 3};
		
		var result = keyList.Cut(newList);
	}
	public static class Ex
	{
		public static List<int> Cut(this List<int> first, List<int> second)
		{
			var skip =
				second
					.Select((x, n) =>  new { x, n })
					.Where(xn => xn.x == first.Last())
					.Where(xn =>
						first
							.Skip(first.Count - xn.n - 1)
							.SequenceEqual(second.Take(xn.n + 1)))
					.Reverse()
					.Select(xn => xn.n + 1)
					.FirstOrDefault();
			return first.Concat(second.Skip(skip)).ToList();
		}
	}
