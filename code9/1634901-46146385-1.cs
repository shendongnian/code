    else // Edit Existing Entry
    {
        // update temp fields here from stocks values
        temp.AverageVolume = stocks.AverageVolume;
        temp.LastTradePrice = stocks.LastTradePrice;
        temp.OneYearTarget = stocks.OneYearTarget;
        temp.Change = stocks.Change;
        temp.ChangePercent = stocks.ChangePercent;
        temp.MarketCap = stocks.MarketCap;
        temp.PriceEarningsRatio = stocks.PriceEarningsRatio;
        temp.DividendYield = stocks.DividendYield;
        temp.EarningsPerShare = stocks.EarningsPerShare;
        db.Entry(temp).State = EntityState.Modified;
        db.SaveChanges();
    }
