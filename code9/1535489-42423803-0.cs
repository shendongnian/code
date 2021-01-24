        delegate void AddBook(int y);
        static void Main()
        {
            AddBook addBook;
            bool IsISBN = false;
            if (IsISBN)
            {
                addBook = AddBookwithISBN;
            }
            else
            {
                addBook = AddBookwithId;
            }
            addBook += x => Console.WriteLine("Added book with :{0}", x);
        }
        public static void AddBookwithId(int y)
        {
            Console.WriteLine("Added Book to the shelf with the ID : {0} ", y);
        }
        public static void AddBookwithISBN(int y)
        {
            Console.WriteLine("Added Book to the shelf  with the ISBN: {0} ", y + 2);
        }
