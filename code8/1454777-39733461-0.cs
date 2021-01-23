    class Program
    {
        static void Main(string[] args)
        {
            List<Book> books = new List<Book>;
            foreach (string line in File.ReadAllLines(@"Duomenys.txt"))
            {
                Book newBook = new Book();
                string[] a = line.Split(',');
                newBook.ISBN = a[0];
                newBook.bookName = a[1];
                newBook.author = a[2];
                newBook.genre = a[3];
                newBook.publisher = a[4];
                newBook.yearPublished = Convert.ToDateTime(a[5]);
                newBook.numberOfPages = Convert.ToInt32(a[6]);
                books.Add(newBook);
            }
            foreach (Book book in books)
            {
               // do stuff here!
            }
    }
    class Book
    {
        public string ISBN { get; set; }
        public string bookName { get; set; }
        public string author { get; set; }
        public string genre { get; set; }
        public string publisher { get; set; }
        public DateTime yearPublished { get; set; }
        public int numberOfPages { get; set; }        
    }
