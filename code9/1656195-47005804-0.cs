    public class Beverage
    {
        public string Description {get;set;}
        public decimal Price {get;set;}
        public override string ToString()
        {
           return $"{this.Description} {(this.Price != 0 ? this.Price.ToString("C") : "")}";
        }
    }
