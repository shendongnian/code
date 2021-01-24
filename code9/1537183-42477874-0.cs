	var results =
		lines
			.Aggregate(new[] { new List<string>() }.ToList(), (a, x) =>
			{
				if (x.StartsWith("Student"))
				{
					a.Add(new List<string>());
				}
				a.Last().Add(x);
				return a;
			})
			.Skip(1)
			.Select(x => new Student(x))
			.ToList();
