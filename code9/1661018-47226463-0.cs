    :
    
        var query = _ctx.SourceItems
                        .Include(i => i.ShopItems)
                        .Include(i => i.Source)
                        .Include(i => i.ShopItems.Select( si => si.Shop))
                        .Include(i => i.ShopItems.Select( si => si.Shop).ShopType)
                        .Where(i => i.LastUpdate > lastUpdate)
                        .OrderBy(i => i.LastUpdate)
                        .Take(updateCountLimit);
    //or 
    
        var query = _ctx.SourceItems
                        .Include("ShopItems")
                        .Include("Source")
                        .Include("ShopItems.Shops")
                        .Include("ShopItems.Shops.ShopType")
                        .Where(i => i.LastUpdate > lastUpdate)
                        .OrderBy(i => i.LastUpdate)
                        .Take(updateCountLimit);
    
