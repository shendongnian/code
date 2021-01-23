    var _transactionsList = TransactionsData.GroupBy(x => x.ItemID).SelectMany(pr =>
     pr.Select(item => new TransactionsTabResults()
     {
        ItemID = pr.Key,
        ItemPrice = item.ItemPrice,
        ItemTitle = item.ItemTitle,
        TotalSoldItems = pr.Count(),
        TotalRevenuePerItem = pr.Sum(y => y.ItemPrice),
        AveragePrice = pr.Average(y => y.ItemPrice),
    })).ToList();
