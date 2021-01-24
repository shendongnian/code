    public class BookNames
    {
        public string BookName { get; set; }
    
        public override bool Equals(object obj)
        {
            var bookNames = obj as BookNames;
    
            return bookNames != null && this.BookName.Equals(bookNames.BookName);
        }
    
        public override int GetHashCode()
        {
            return this.BookName?.GetHashCode() ?? 0;
        }
    }
