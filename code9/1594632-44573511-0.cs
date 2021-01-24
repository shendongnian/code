    private static MyDbContext _dbContext;
    private static IQueryable<DenormalizedType> SelectType()
    {
        _dbContext = new MyDbContext();
        var myData = (from some in dbContext.Thing 
            join other in dbContext.OtherThing
            on some.OtherId equals other.Id
            select new DenormalizedType()
            {
                SomeEntry = some.Entry
                SomeOtherId = some.OtherId
                OtherValue = other.Value
            };
        return myData;
    }
