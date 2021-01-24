    public class Author
    {
        // Restrict creation of books to just the once, at construction time
		private readonly ICollection<Book> _books;
        public Author()
        {
            _books = new List<Book>();
        }
		public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        // Take away the setter, and prevent direct external change to the collection
		public virtual IEnumerable<Book> Books
        {
            get { return _books; }
        }
		// Provide a more controlled mechanism to book creation
		public void PublishBook(int id, string title, string publisher)
		{
		    _books.Add(new Book(this)
			{
				Id = id,
				Title = title,
				Publisher = publisher
			});
		}
    }
	
    public class Book
    {
        private readonly ICollection<Author> _authors;
        // Book cannot be published without an author
		public Book(Author author)
        {
            _authors = new List<Author>{author};
        }
        public int Id { get; set; }
        public string Title{get; set;}
        public string Publisher { get; set; }
        // As above, don't allow direct change
		public virtual IEnumerable<Author> Authors
        {
            get { return _authors; }
        }
    }	
