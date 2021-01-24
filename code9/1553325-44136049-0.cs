    public class Book
    {
        public string Name { get; set; }
        public string Details { get; set; }
        public List<string> Notes { get; set; }
        public string NotesStr => String.Join(",", Notes);
    }
