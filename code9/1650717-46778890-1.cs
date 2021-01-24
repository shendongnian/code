    public class Paged<T>
    {
        public PageInfo Paging { get; set; }
        public T[] Items { get; set; }
    }
    public class PageInfo
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; } = 20;
    }
    public class PagedQuery<TQuery, TItem> : IQuery<Paged<TItem>>
        where TQuery : IQuery<IQueryable<TItem>>
    {
        public TQuery Query { get; set; }
        public PageInfo PageInfo { get; set; }
    }
