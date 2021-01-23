    public interface IPagedList<T> : IList<T>
    {
        int PageCount { get; set; }
        int PageSize { get; set; }
        int PageNumber { get; set; }
        int TotalItemsCount { get; set; }
    }
    public class PagedList<T> : List<T>, IPagedList<T>
        where T : class
    {
        public int PageCount { get; set; }
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
        public int TotalItemsCount { get; set; }
    }
