     var debug = TransactionsData
    .Where(a=>a.ItemID = testID)
    .GroupBy(x => new { x.ItemID, x.Title, x.GalleryURL })
    .Select(pr => new  
    {
		ItemID              = pr.Key.ItemID,
		Title               = pr.Key.Title,
		GalleryURL          = pr.Key.GalleryURL,
	    LatestSale          = pr.OrderByDescending(a=>a.Date).First() ,
        AllSales            = pr.ToList(),
		
		ItemPrice           = pr.OrderByDescending(a=>a.Date).First().ItemPrice ,
		
		TotalSoldItems      = pr.Count(),
		TotalRevenuePerItem = pr.Sum(y => y.ItemPrice),
		AveragePrice        = pr.Average(y => y.ItemPrice),
	}
	).ToList();
