	foreach (var g in grouped)
	{
		Console.WriteLine(g.Key.Name);
		Console.WriteLine(g.Key.ID);
		Console.WriteLine(string.Join("\n", g.Select(c => c.Car)));
		Console.WriteLine();
	}
