    class BookDA // DAO = data access
    {
        private MyDbConnection db;
        public BookTO Get()
        {
            var book = db.Books.Single(d => d.BookId == id);
            return book;
        }
    }
    class BookTO // TO = transport object
    {
        public string Name { get; set; }
    }
