    public object[] QueryDynamicData(string table, int entityId) {    
       //Your DbContext that contains all of your 
       var dbContext = new FooBaa() 
       //Get the DbSet in your DbContext that matches the "Table" name.
       //You are searching for the generic parameter of the DbSet
       var dbSetInfo = dbContext.GetType().GetProperties().FirstOrDefault(e => e.GetGenericArguments().Any(f => f.Name.Equals(table)); 
       //Now get the DbSet from the DbContext and cast it to an IQueryabe
       IQueryable anyDbSet = (IQueryable)dbSetInfo.GetValue(dbContext);
       //Use Dynamic Linq to create a Query that selects an ID
       return anyDbSet.Where("Id=" + entityId).ToArray();
    }
