    // whatever you search for... this assumes you want coins for one store in one timeframe
    int desiredStoreID = 0, desiredTimeFrameID = 0;
    var coinUsedSelection = db.CoinUsed
        .Where(x => x.StoreID == desiredStoreID && x.TimeFrameID == desiredTimeFrameID)
        .SelectMany(x => x.CoinUsedItems)
        .GroupBy(x => x.CoinID, x => x.QuantityUsed, (k, v) => new { CoinID = k, QuantityUsedSum = v.Sum() });
    var coinAllocationSelection = db.CoinAllocations
        .Where(x => x.StoreID == desiredStoreID && x.TimeFrameID == desiredTimeFrameID)
        .SelectMany(x => x.CoinAllocationItems)
        .GroupBy(x => new { x.CoinID, x.Coin.CoinName }, x => x.QuantityAllocated, (k, v) => new { k.CoinID, k.CoinName, QuantityAllocatedSum = v.Sum() });
    var result = coinAllocationSelection.Join(coinUsedSelection, ca => ca.CoinID, cu => cu.CoinID, (ca, cu) => new
        {
            CoinName = ca.CoinName,
            AmountAllocated = ca.QuantityAllocatedSum,
            AmountUsed = cu.QuantityUsedSum,
            Remaining = ca.QuantityAllocatedSum - cu.QuantityUsedSum
        })
        .ToList();
