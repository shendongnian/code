        public List<Book> books = new List<Book>();
        public void addBook(string title, string author)
        {
            var bookQuantity = int.Parse(Console.ReadLine());
            
            for (int x = 0; x <= bookQuantity; x++)
            {
                Console.WriteLine("Enter Title:");
                var btitle = Console.ReadLine();
                Console.WriteLine("Enter Author:");
                var bauthor = Console.ReadLine();
                books.Add(new Book() { title = btitle, author = bauthor, ID = x + 1, isbn = x + 1 });
            }
        }
        public void findBook()
        {
            Console.WriteLine("Enter ID:");
            var id = int.Parse(Console.ReadLine());
            Book result = books.FirstOrDefault((book => book.ID == id));
        }
        public void displayBooks()
        {
            foreach (Book b in books)
            {
                Console.WriteLine(b.ToString());
            }
        }
        public void removeBook()
        {
            Console.WriteLine("Enter ID:");
            var id = int.Parse(Console.ReadLine());
            var temp = books.FirstOrDefault(book => book.ID == id);
            if (temp != null)
                books.Remove(temp);
        }
    }
    public class Book
    {
        public string title { get; set; }
        public string author { get; set; }
        public int isbn { get; set; }
        public int ID { get; set; }
        public override string ToString()
        {
            return string.Format("Title: " + title, "\nAuthor: " + author, "\nISBN: " + ID);
        }
    }
