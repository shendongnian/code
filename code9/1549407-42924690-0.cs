      public interface IBook
    {
        string Name { get; set; }
        ICollection<IAuthor> GetAuthors();
        void AddAuthor(IAuthor book);
        int PagesCount { get; set; }
    }
    public interface IAuthor
    {
        string Name { get; set; }
        ICollection<IBook> GetBooks();
        void AddBook(IBook book);
    }
    public class Author : IAuthor
    {
        private ICollection<IBook> books;
        public Author()
        {
            this.books = new HashSet<IBook>();
        }
        public Author(ICollection<IBook> books)
        {
            this.books = books;
        }
        public string Name { get; set; }
        public void AddBook(IBook book)
        {
            this.books.Add(book);
        }
        public ICollection<IBook> GetBooks()
        {
            return this.books;
        }
    }
    public class Book : IBook
    {
        private ICollection<IAuthor> authors;
        public Book()
        {
            this.authors = new HashSet<IAuthor>();
        }
        public Book(ICollection<IAuthor> Authors)
        {
            this.authors = Authors;
        }
        public void AddAuthor(IAuthor author)
        {
            this.authors.Add(author);
        }
        public ICollection<IAuthor> GetAuthors()
        {
            return this.authors;
        }
        public string Name { get; set; }
        public int PagesCount { get; set; }
    }
 
