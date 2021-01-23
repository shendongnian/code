    using(dbContext = dbContext.CreateContext())
    { 
        var setData = dbContext.Table1Set().Include(t => t.Table2);
    }
    var foo = ...;
    var results = setData.Where(t => t.Table2.Field = foo);
