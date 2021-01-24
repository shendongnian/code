	string text = "My school Name is stack over flow High school.";
	List<string> lines =
		text
			.Split(' ')
			.Aggregate(new [] { "" }.ToList(), (a, x) =>
			{
				var last = a[a.Count - 1];
				if ((last + " " + x).Length > 40)
				{
					a.Add(x);
				}
				else
				{
					a[a.Count - 1] = (last + " " + x).Trim();
				}
				return a;
			});
