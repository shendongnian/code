        public class PagingSettings
    {
        public PagingSettings()
            : this(50, 1)
        { }
        protected PagingSettings(int pageSize, int pageNumber)
        {
            PageSize = pageSize;
            PageNumber = pageNumber;
        }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
