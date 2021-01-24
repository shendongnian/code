    if(!string.IsNullOrEmpty(_txtboxId_)
    {
        items = dbContext.Items.Where(m => m.Id.Contains(_txtboxId_); 
    }
    else
        items = dbContext.Items.ToList();
    
    if(!string.IsNullOrEmpty(_txtboxBuyer_)
    {
        items = dbContext.Items.Where(m => m.Id.Contains(_txtboxBuyer_);
    
    }
    else
        items = dbContext.Items.ToList();
    
    if(!string.IsNullOrEmpty(_txtboxPrice_)
    {
        items = dbContext.Items.Where(m => m.Id.Contains(_txtboxPrice_);
    
    }
    
    items = dbContext.Items.ToList();
   
