    var _transactionsList = TransactionsData
    .GroupBy(x => new { x.ItemID, x.Title, x.GalleryURL })
    .Select(pr => new TransactionsTabResults
    {
		ItemID              = pr.Key.ItemID,
		Title               = pr.Key.Title,
		GalleryURL          = pr.Key.GalleryURL,
		
		ItemPrice           = pr.OrderByDescending(a=>a.Date).First().ItemPrice ,
		
		TotalSoldItems      = pr.Count(),
		TotalRevenuePerItem = pr.Sum(y => y.ItemPrice),
		AveragePrice        = pr.Average(y => y.ItemPrice),
	}
	).ToList();
