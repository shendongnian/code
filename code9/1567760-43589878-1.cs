    var ids = user.Items
		.GroupBy(x => x.ItemId)
		.Where(x=> x.Any())
        .Select(pr => pr.First().Id); /* No ToList yet */
		
	user
		.Items
		.Where(x=> ids.Contains(x.Id)) // <--
		.Select(pr => new SalesViewModel
		{
			ImageURL = x.ImageURL,
			Title= x.Title,
			Sales = x.Transactions.Sum(y=>y.QuantitySold)
		})
		.ToList();
