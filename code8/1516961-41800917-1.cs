    public static class Extensions
    {
        public static IQueryable<T> Paging<T>(this IQueryable<T> source, int pageNumber, int pageLength)
        {
            return source.Skip(pageNumber * pageLength).Take(pageLength);
        }
    }
    var source = (from trans in DB.transactions 
    orderby "cancellation_reason_id" descending 
    select trans);
    
    source = source.Paging(0, 10); // Get first page with 10 item
