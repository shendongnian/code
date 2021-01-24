    if (matches == null || !matches.Any())
    {
        return null;
    }
    return (from ESMatch in matches
            group ESMatch by ESMatch.BeginDate.Date into newGroup
            orderby Convert.ToDateTime(newGroup.Key)
            select new ESMatchDate 
            {
                Date = d.Key,
                Matches = d.ToList()
            }).ToList();
