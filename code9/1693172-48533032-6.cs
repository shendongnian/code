    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ReadOnlyCollection<string> Books { get; }
        public Author(params string[] books)
        {
            Books = new ReadOnlyCollection<string>(books);
        }
    }
