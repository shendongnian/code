    List<Soda> sodaList = new List<Soda>();
    // Constructor within class Sodacrate
    public class Soda
    {
        //CLASS PROPERTIES
        public string Name {get; set;}
        public decimal Price {get; set;}
        //CLASS CONSTRUCTOR
        public Soda(string name, decimal price)
        {
            Name = name;
            Price = price;
        }
    }
