    private static IEnumerable<Item> GetSimilarItems(int days, string type, 
                                                     float counterOne, float counterTwo)
    {
        var similarSubItems = new HashSet<string>();
        var c9 = counterOne * 0.9;
        var c1 = counterOne * 1.1;
        if (days > 180)
        {
            foreach (var p in SubItemCache.Values)
                if (p.CounterOne >= c9 && p.CounterOne <= c1)
                    similarSubItems.Add(p.ID);
        }
        else
        {
            foreach (var p in SubItemCache.Values)
                if (p.CounterTwo >= c9 && p.CounterTwo <= c1)
                    similarSubItems.Add(p.ID);
        }
        var days0 = days - 5;
        var days1 = days + 5;
        foreach (var p in ItemCache.Values) 
            if (p.days >= days0 && p.days <= days1 
                                && p.Type == type && similarSubItems.Contains(p.Key))
                yield return p;
    }
