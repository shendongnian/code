      public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<string> Books { get; }
        public Author(params string[] books)
        {
            Books = new List<string>(books);
        }
    }
