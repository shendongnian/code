    class Book
    {
    public int BookNum { get; set; }
    public string BookTitle { get; set; }
    public string BookAuthor { get; set; }
    public double BookPrice { get; set; }
    public string BookGrade = "N/A";
    
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
        get
        {
            return base.BookPrice;
        }
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
        get
        {
            return base.BookPrice;
        }
    }
    }
