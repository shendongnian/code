    public class Book : Activity
    {
        public Book() : base(ActivityType.Book) { }
        public Book(object[] values) : base(values)
        {
            if (values.Length != 4) throw new ArgumentException();
            this.ISBN = getString(values[3]);
        }
        public string ISBN { get; set; }
    }
    public class Journal : Activity
    {
        public Journal() : base(ActivityType.Journal) { }
        public Journal(object[] values) : base(values)
        {
            if (values.Length != 5) throw new ArgumentException();
            this.Volume = getInt(values[3]);
            this.Issue = getInt(values[4]);
        }
        public int Volume { get; set; }
        public int Issue { get; set; }
    }
    public class Grant : Activity
    {
        public Grant() : base(ActivityType.Grant) { }
        public Grant(object[] values) : base(values)
        {
            if (values.Length != 4) throw new ArgumentException();
            this.Volume = getDecimal(values[3]);
        }
        public decimal Volume { get; set; }
    }
