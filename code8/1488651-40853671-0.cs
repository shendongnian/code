    var _transactionsList = TransactionsData.GroupBy(x => x.ItemID).Select(pr =>
    new
    {
        ItemID = pr.Key,
        GroupedItems = pr.ToList(),
        TotalSoldItems = pr.Count(),
        TotalRevenuePerItem = pr.Sum(y => y.ItemPrice),
        AveragePrice = pr.Average(y => y.ItemPrice),
    });
