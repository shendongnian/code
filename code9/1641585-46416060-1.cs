	var grid = new object[clients.Count() + 1, products.Count() + 1];
	var lookup = prices.ToLookup(x => new { x.cid, x.pid }, x => x.price);
	for (var p = 0; p < products.Count(); p++)
	{
		grid[0, p + 1] = products[p];
	}
	for (var c = 0; c < clients.Count(); c++)
	{
		grid[c + 1, 0] = clients[c];
		for (var p = 0; p < products.Count(); p++)
		{
			var values = lookup[new { cid = clients[c], pid = products[p] }];
			grid[c + 1, p + 1] = values.Any() ? (decimal?)values.Sum() : null;
		}
	}
