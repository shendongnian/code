    IQueryable<Item> items;
    if(!string.IsNullOrEmpty(_txtboxId_)
    {
        items = dbContext.Items.Where(m => m.Id.Contains(_txtboxId_); 
    }
    else
    {
        items = dbContext.Items;
    }
    if(!string.IsNullOrEmpty(_txtboxBuyer_)
    {
        items = items.Where(m => m.Id.Contains(_txtboxBuyer_);
    }
    
    if(!string.IsNullOrEmpty(_txtboxPrice_)
    {
        items = items.Where(m => m.Id.Contains(_txtboxPrice_);
    }
    
    return items.ToList()
