    var byTotalViews = movieRankData.OrderByDescending(m => m.TotalViews.Value).Select((item, index) => new { item, index }).ToDictionary(e => e.item);
    var byTotalMoney = movieRankData.OrderByDescending(m => m.TotalMoney.Value).Select((item, index) => new { item, index }).ToDictionary(e => e.item);
    foreach (var movie in movieRankData)
    {
        movie.TotalViews.Rank = byTotalViews[movie].index + 1;
        movie.TotalMoney.Rank = byTotalMoney[movie].index + 1;
    }
