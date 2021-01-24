    using (var oldDbContext = ...)
    {
        using (var newDbContext = ...)
        {
             var oldItems = oldDbContext.OldTable.ToList();
             foreach (var oldItem in oldItems)
             {
                 var newItem = converOldItem(newItem);
                 // you need your Id to have default value (zero)!
                 var addedNewItem = newDbcontext.NewTable.Add(newItem);
             }
             ...
             newDbContext.SaveChanges();
         }
    }
