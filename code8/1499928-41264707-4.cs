    class Page<T>
    {
        public int PageSize {get; set;}
        public int PageNr {get; set;}
        public IEnumerable<T> Contents {get; set;}
    }
