    public override void InitializeDatabase(AppContext context)
    {
    
       if (!context.StoreTypes.Any(st => st.Name == "Local"))
       {
           var newStoreType = new StoreType { Name = "Local", Description = "Local" };
           context.SaveChanges();  // newStoreType will now have id
           var storesToUpdate = context.Stores.Where(s => s.StoreTypeId == 0);
           storesToUpdate.ForEach(s => s.StoreTypeId = newStoreType.Id);
           context.SaveChanges();
       }
    }
