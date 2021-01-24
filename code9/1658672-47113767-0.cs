    private ITEM CheckStatusOfItems(IQueryable<ITEM> items)
    {
        var query =
            from item in items
            let lastStatusOfItem = ERPContext.ITEMTRACKER
                .Where(it => it.ItemID == item.ItemID)
                .OrderByDescending(it => it.ItemTrackerID)
                .FirstOrDefault()
            where (lastStatusOfItem.ItemStatus == (int)ItemStatus.Failed || lastStatusOfItem.ItemStatus == (int)ItemStatus.Confirmed)
            select item;
    
        return query.FirstOrDefault();
    }
