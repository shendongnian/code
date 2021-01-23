    public static IOrderedQueryable<BaseEntity> Randomize(
                             this IQueryable<BaseEntity> queryable)
    {
        var seed = Random.NextDouble();
    
        return queryable.OrderBy(o => SqlFunctions.Checksum(o.Id * seed))
                         .ThenBy(o => o.Id);
    }
