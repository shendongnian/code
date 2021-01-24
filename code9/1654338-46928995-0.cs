    class Program
    {
        class Book
        {
            public int BookNum { get; set; }
            public string BookTitle { get; set; }
            public string BookAuthor { get; set; }
            public double BookPrice { get; set; }
            public override string ToString() //!
            {
                return string.Format("{0} {1} {2} {3}", this.BookNum, this.BookTitle, this.BookAuthor, this.BookPrice);
            }
        }
        class TextBook : Book // must be priced between $20.00 and $80.00
        {
            const double MIN_PRICE = 20;
            const double MAX_PRICE = 80;
            public string BookGrade { get; set; }
            new public double BookPrice
            {
                set
                {
                    if (value < MIN_PRICE)
                    {
                        base.BookPrice = MIN_PRICE;
                    }
                    else if (value > MAX_PRICE)
                    {
                        base.BookPrice = MAX_PRICE;
                    }
                    else
                    {
                        base.BookPrice = value;
                    }
                }
                get { return base.BookPrice; }
            }
            public override string ToString() //!
            {
                return base.ToString() + " " + this.BookGrade;
            }
        }
        class CoffeeTableBook : Book //must be priced between $35.00 and $100.00
        {
            const double MIN_PRICE = 35;
            const double MAX_PRICE = 100;
            new public double BookPrice
            {
                set
                {
                    if (value < MIN_PRICE)
                    {
                        base.BookPrice = MIN_PRICE;
                    }
                    else if (value > MAX_PRICE)
                    {
                        base.BookPrice = MAX_PRICE;
                    }
                    else
                    {
                        base.BookPrice = value;
                    }
                }
                get { return base.BookPrice; }
            }
        }
        private static void Main(string[] args)
        {
            //Book
            var book1 = new Book
            {
                BookNum = 123456,
                BookTitle = "Harry Potter 1",
                BookAuthor = "JK Rowling",
                BookPrice = 5.95
            };
            //Text Book
            var TBook1 = new TextBook
            {
                BookNum = 123436,
                BookTitle = "Harry Potter 2",
                BookAuthor = "JK Rowling",
                BookPrice = 5.95,
                BookGrade = "A"
            };
            //Coffee Table Book
            var CBook1 = new CoffeeTableBook
            {
                BookNum = 123136,
                BookTitle = "Harry Potter 7",
                BookAuthor = "JK Rowling",
                BookPrice = 95.95
            };
            var bookArray = new Book[] {book1, TBook1, CBook1};
            foreach (Book t in bookArray)
            {
                Console.WriteLine(t); //! i.e Console.WriteLine(t.ToString());
            }
        }
