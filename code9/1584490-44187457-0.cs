    public class Library
    {
        public string Name { get; set; }
        public List<Book> BookList { get; set; }
        public Library()
        {
            string[] books = new string[5] { "HR", "HR", "Tiger","Lion", "Elephant" };
            BookList = new List<Book>();
            foreach (string s in books) {
                Book b = new Book(s);
                b.borrowed += borrowed;
                BookList.Add(b);
            }
        }
        private void borrowed(Book b)
        {
            BookList.Remove(b);
        }
    }
    public class Book
    {
        public delegate void BorrowedEventHandler(Book b);
        public event BorrowedEventHandler borrowed;
        public string Name { get; set; }
        public Book(string name)
        {
            Name = name;
        }
        public void borrow()
        {
            borrowed(this);
        }
    }
