    public class Book
    {
        public int BookId { get; set; }
        public string BookName { get; set; }
    }
    public class Author
    {
        public int AuthorId { get; set; }
        public string AuthorName { get; set; }
    }
    public class Author_Book
    {
        public int AuthorId { get; set; }
        public int BookId { get; set; }
    }
    public class Example
    {
        public void Linq()
        {
            List<Book> books = new List<Book>();
            books.Add(new Book { BookId = 1, BookName = "Book1" });
            books.Add(new Book { BookId = 2, BookName = "Book2" });
            books.Add(new Book { BookId = 3, BookName = "Book3" });
            List<Author> authors = new List<Author>();
            authors.Add(new Author { AuthorId = 1, AuthorName = "Author1" });
            authors.Add(new Author { AuthorId = 2, AuthorName = "Author2" });
            List<Author_Book> bookAuthors = new List<Author_Book>();
            bookAuthors.Add(new Author_Book { AuthorId = 1, BookId = 1 });
            bookAuthors.Add(new Author_Book { AuthorId = 1, BookId = 3 });
            bookAuthors.Add(new Author_Book { AuthorId = 2, BookId = 1 });
            bookAuthors.Add(new Author_Book { AuthorId = 2, BookId = 2 });
            bookAuthors.Add(new Author_Book { AuthorId = 2, BookId = 3 });
            var selectedBooks = from b in books
                                join ba in bookAuthors on b.BookId equals ba.BookId into ab
                                from a in ab.Where(x => x.AuthorId == 1).DefaultIfEmpty()
                                where (a == null)
                                select b;
       }
    }
