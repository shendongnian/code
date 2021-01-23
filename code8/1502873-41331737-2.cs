    TransactionsData
    .GroupBy(x => x.ItemID)
    .Select(pr => 
    {
        var items = x.pr.ToArray;
        var sum = items.Sum(y => y.ItemPrice);
        return new TransactionsTabResults
        {
            ItemID = pr.Key,
            Title = items[0].Title,
            GalleryURL = items[0].GalleryURL,
            ItemPrice = pr.Aggregate((max, cur)=>max.TransactionDate<cur.TransactionDate?cur:max).ItemPrice,
            TotalSoldItems = items.Length,
            TotalRevenuePerItem = sum,
            AveragePrice = sum/items.Length,
        };
    }).ToList();
