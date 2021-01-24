	.Select(g => new
	{
		Book = g.Key.Book,
		Chapter = g.Key.Chapter,
		MinTimesRead = g.Min(d => d.TimesRead),
		Items = g.Select(i => i)
	});
