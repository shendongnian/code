        public Author(string name)
        {
            Name = name;
            Books = new List<Book>();
        }
        public string Name { get; set; }
        public List<Book> Books { get; set; }
    }
