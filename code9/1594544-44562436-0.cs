    class Article
    {
        DateTime LastModified { get; set; }
    }
    ...
    foreach(var article in articles)
    {
        var timespan = DateTime.Now - article.LastModified;
        if(timeSpan.TotalDays >= 1) ...
    }
