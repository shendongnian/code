    // declared at class level
    private static readonly object ItemCreationSyncLock = new object();
    public void MyMethodThatCreatesAnItem()
    {
        // ... setup code ...
        var item = _dbContext.Items.FirstOrDefault(itm => item.Name == criteria);
        if(item == null)
        {
            lock(ItemCreationSyncLock)
            {
                item = _dbContext.Items.FirstOfDefault(itm => item.Name == criteria);
                if(item == null)
                {
                    item = new Item { Name = criteria };
                    _dbContext.Items.Add(item);
                    _dbContext.SaveChanges();
                }
            }
        }
    }
