    class Author
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<string> Books { get; } = new List<string>();
        public Author(params string[] books)
        {
            Books.AddRange(books);
        }
    }
    
    class Project
    {
        void Main()
        {
            Author a = new Author("Asp.net", "C++", "C#")
            {
                Id = 100,
                Name = "Bill Gates"
            };
        }
    }
