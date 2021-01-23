    using(dbContext = dbContext.CreateContext())
    { 
        var setData = dbContext.Table1Set().Include(t => t.Table2);
    }
    var foo = ...;
    var results = setData.where(t => t.Table2.Field = foo);
