        public class DB
        {
            public class Book
            {
                public string Title;
                public List<Author> Authors
                {
                    get
                    {
                        return
                            BookAuthor.Connection.Where(ba => ba.Book.Title == this.Title)
                                .Select(ba => ba.Author)
                                .ToList();
                    }
                }
                public void AddAuthor(Author a)
                {
                    var connection = new BookAuthor(this, a);
                    if (!BookAuthor.Connection.Exists(c => c.Author.Name == connection.Author.Name &&
                                                          c.Book.Title == connection.Book.Title))
                        BookAuthor.Connection.Add(connection);
                }
            }
            public class Author
            {
                public string Name;
                public List<Book> Books
                {
                    get
                    {
                        return
                            BookAuthor.Connection.Where(ba => ba.Author.Name == this.Name)
                                .Select(ba => ba.Book)
                                .ToList();
                    }
                }
                public void AddBook(Book b)
                {
                    var connection = new BookAuthor(b, this);
                    if (!BookAuthor.Connection.Exists(c => c.Author.Name == connection.Author.Name &&
                                                          c.Book.Title == connection.Book.Title))
                        BookAuthor.Connection.Add(connection);
                }
            }
            private class BookAuthor
            {
                public Book Book { get; set; }
                public Author Author { get; set; }
                public static List<BookAuthor> Connection { get; } = new List<BookAuthor>();
                public BookAuthor(Book book, Author author)
                {
                    Book = book;
                    Author = author;
                }
            }
        }
        public void Run()
        {
            List<DB.Book> books = new List<DB.Book>()
            {
                new DB.Book() {Title = "Crime & Punishment"},
                new DB.Book() {Title = "Karamazov"}
            };
            List<DB.Author> authors = new List<DB.Author>()
            {
                new DB.Author()
                {
                    Name = "Dostoyevsky",
                    Books = { books[0] }
                }
            };
            authors[0].AddBook(books[1]);
            authors[0].AddBook(books[1]); // constraint
            List<DB.Book> allBooksOfDostoyevsky = authors[0].Books;
            var dost = authors[0].Books[0].Authors[0].Name; // Dostoyevsky
        }
