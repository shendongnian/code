    public class Book : Activity
    {
        public Book() : base("Book") { }
        public string ISBN { get; set; }
    }
    public class Journal : Activity
    {
        public Journal() : base("Journal") { }
        public int Volume { get; set; }
        public int Issue { get; set; }
    }
