    class BookFilter
    {
        public string NameStartsWith { get; set; }
        public string ISBN { get; set; }
        public DateTime PublishedAfter { get; set; }
        // ....
    }
    public interface IBookRepository  
    {
        IList<Book> Filter(BookFilter filter);
    }
