    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Book> AuthorBooks { get; set; }
    }
    
    public class Book
    {
        public string Title { get; set; }
        public string Isbn { get; set; }
    }
