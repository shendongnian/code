    public static IOrderedQueryable<BaseEntity> Randomize(
                             this IQueryable<BaseEntity> queryable)
    {
        var seed = (double)Random.Next();
    
        return queryable.OrderBy(o => SqlFunctions.Checksum(o.Id * seed))
                         .ThenBy(o => o.Id);
    }
