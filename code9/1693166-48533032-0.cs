    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<string> Books { get; private set; }
    
        public Author()
        {
            Books = new List<string>();
        }
    }
