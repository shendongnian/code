    public static IQueryable<T> WhereActive<T>(this IQueryable<T> query) 
        where T : Entities.Core.BaseObject
    {
        // no need to specify the generic <T> here as well...
        return query.Where(b => !b.IsDeleted);
    }
