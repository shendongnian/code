    private IEnumerable<ESMatchDate> groupBydate(IEnumerable<ESMatch> matches)
    {
    
        if (null == matches || !matches.Any())
        {
            return null;
        }
        return matches.GroupBy(x => x.BeginDate.Date)
                      .OrderBy(x => x.Key)
                      .Select(x => new ESMatchDate{ Date = x.Key, Matches = x.ToList() }) 
                      .ToList();
    }
