    class Book {
        public int ID { get; set; }
        public string Title { get; set; }
    }
    
    class Author {
        public int ID { get; set; }
        public string Name { get; set; }
    }
    
    class BookAuthorConnections {
        public int ID_Book { get; set; }
        public int ID_Author { get; set; }
    }
