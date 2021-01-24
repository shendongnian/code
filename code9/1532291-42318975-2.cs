    public class AirportItem
    {
        public string Name {get;set;}
        public string Country {get;set;}
        public override string ToString()
        {
            return string.Join(", ", this.Name, this.Country);
        }
    }
