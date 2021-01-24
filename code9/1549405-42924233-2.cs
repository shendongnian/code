    public class Book
    {
        public string Name { get; set; }
        public Author[] Authors { get; set; }
        public int PageCount { get; set; }
    }
    
    public class Author
    {
        public string Name { get; set; }
        public Book[] Books { get; set; }
    }
