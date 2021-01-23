    var byTotalViews = movieRankData.OrderByDescending(m => m.TotalViews.Value).ToList();
    var byTotalMoney = movieRankData.OrderByDescending(m => m.TotalMoney.Value).ToList();
    foreach (var movie in movieRankData)
    {
        movie.TotalViews.Rank = byTotalViews.IndexOf(movie) + 1;
        movie.TotalMoney.Rank = byTotalMoney.IndexOf(movie) + 1;
    }
