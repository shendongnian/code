    var someCats = cats.Select(x =>
    {
        var lft = x.FeedingTimes.Max(y => (DateTime?)y);
        return new
        { 
            x.Name, 
            x.IsMale, 
            LatestFeedingTime = lft, 
            WasFedRecently = lft >= DateTime.Today.AddDays(-1)
        };
    });
