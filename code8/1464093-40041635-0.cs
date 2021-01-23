    public class Book
    {
        public string Name { get; set;}
        public strain Author {get; set;}
        public string ISBN {get ;set;}
        public int Price {get; set;}
        public override string ToString()
        {
            return string.Format("{0} - {1}", Name, Author);
        }
    }
