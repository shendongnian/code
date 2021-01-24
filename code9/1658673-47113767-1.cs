    private ITEM CheckStatusOfItems(IQueryable<ITEM> items)
    {
        var query =
            from item in items
            from lastStatusOfItem in ERPContext.ITEMTRACKER
                .Where(it => it.ItemID == item.ItemID)
                .OrderByDescending(it => it.ItemTrackerID)
                .Take(1)
            where (lastStatusOfItem.ItemStatus == (int)ItemStatus.Failed || lastStatusOfItem.ItemStatus == (int)ItemStatus.Confirmed)
            select item;
    
        return query.FirstOrDefault();
    }
