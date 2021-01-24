    list.GroupBy(
        g => new 
        {
            g.Name, 
            Date = g.Date.AddSeconds(-g.Date.Second).AddMilliseconds(-g.Date.Millisecond)
        }).Select(d => d.First())
        .OrderBy(d => d.Date).ToList();
