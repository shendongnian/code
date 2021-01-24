    public interface IPageableQuery {
        // The page size (i.e. the number of elements to be displayed).
        // The method processing the Query will Take() this number of elements.
        int DisplayLength { get; set; }
    
        // The number of elements that have already been displayed.
        // The method processing the Query will Skip() over these elements.
        int DisplayStart { get; set; }
    }
    public static IQueryable<T> ApplyPaging<T>(this IQueryable<T> entries, IPageableQuery query)
        where T : class {
        if (query.DisplayStart >= 0 && query.DisplayLength > 0) {
            return entries.Skip(query.DisplayStart).Take(query.DisplayLength);
        }
        return entries;
    }
