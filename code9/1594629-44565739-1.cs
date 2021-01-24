    public DenormalizedType GetData(Func<Thing, bool> predicate)
    {
        using (var dbContext = new MyDbContext())
        { 
            var myData = (from some in dbContext.Thing 
            join other in dbContext.OtherThing
            on some.OtherId equals other.Id
            where predicate(some) //check this
            select new DenormalizedType()
            {
                SomeEntry = some.Entry
                SomeOtherId = some.OtherId
                OtherValue = other.Value
            }).ToList();
        }
    }
