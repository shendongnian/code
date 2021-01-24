    public static Dictionary<string, SubItem> SubItemCache = new Dictionary<string, SubItem>();
    public static Dictionary<string, Item> ItemCache = new Dictionary<string, Item>();
    
    private static IEnumerable<Item> GetSimilarItems(int days, string type, 
        float counterOne, float counterTwo)
    {
        HashSet<string> similarSubItems;
    
        if (days > 180)
        {
            similarSubItems = new HashSet<string>(SubItemCache.Values
                .Where(p => p.CounterOne >= counterOne * 0.9 
                    && p.CounterOne <= counterOne * 1.1)
                .Select(o => o.ID));
        }
        else
        {
            similarSubItems = new HashSet<string>(SubItemCache.Values
                .Where(p => p.CounterTwo >= counterTwo * 0.9 
                    && p.CounterTwo <= counterTwo * 1.1)
                .Select(o => o.ID));
        }
    
        var selection = ItemCache.Values.Where(p => p.days >= days - 5 && p.days <= days + 5
                                              && p.Type == type
                                              && similarSubItems.Contains(p.Key));
    
        return selection;
    }
