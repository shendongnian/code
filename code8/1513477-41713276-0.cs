	var source = @"Path    Description
    1            a
    1.1          b
    1.1.1        c
    1.2          d
    1.3          e";
	var lines =
		source
			.Split(Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
			.Select(x => x.Split(new [] { ' ' }, StringSplitOptions.RemoveEmptyEntries));
	var results =
		lines
			.Skip(1)
			.Select(x => new
			{
				Indent = x[0].Count(y => y == '.'),
				Path = x[0],
				Description = x[1]
			})
			.Select(x =>
				String.Format(
					"{0}{1}{2}{3}",
					"".PadLeft(x.Indent + 1).Substring(1),
					x.Path,
					"".PadLeft(15 - x.Path.Length - x.Indent),
					x.Description));
					
	Console.WriteLine(String.Join(Environment.NewLine, results));
