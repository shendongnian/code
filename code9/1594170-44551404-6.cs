    class Book
    {
        public String ISBN;
        public String Author;
        public double Price;
        private static int Quantity;
        public static int readNumber() { return Quantity; }
        public Book()
        {
            this.ISBN = "no ISBN"; this.Author = "no Author"; this.Price = 0.0;
            System.Threading.Interlocked.Increment(ref Quantity);
        }
        ~Book() { System.Threading.Interlocked.Decrement(ref Quantity); }
    }
 
    class Program
    {
        static void Main()
        {
            Book one = new Book();
            Book two = new Book();
            Console.WriteLine(Book.readNumber());   // Outputs 2
            Console.ReadKey();
        }
    }
