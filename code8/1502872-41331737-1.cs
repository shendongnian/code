    TransactionsData
    .GroupBy(x => x.ItemID)
    .Select(pr => new TransactionsTabResults
    {
        ItemID = pr.Key,
        Title = pr.First().Title,
        GalleryURL = pr.First().GalleryURL,
        ItemPrice = pr.OrderByDescending(a => a.TransactionDate).First().ItemPrice,
        TotalSoldItems = pr.Count(),
        TotalRevenuePerItem = pr.Sum(y => y.ItemPrice),
        AveragePrice = pr.Average(y => y.ItemPrice),
    }).ToList();
