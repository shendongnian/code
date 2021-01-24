    [JsonObject]
    public class PagedList<T> : List<T>, IPagedList<T>
    {
        public PagedList(IQueryable<T> source)
        {
            AddRange(source);
        }
        public IEnumerable<T> Data => this.ToList();
        public int TotalCount { get; private set; }
    }
