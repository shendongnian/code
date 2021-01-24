    public enum BeverageType
    {
        Soda,
        Juice,
        Water,
        Alcohol
    }
    public class Beverage
    {
        public string Name { set; get; }
        public BeverageType Type { set; get; }
        public decimal Price { set; get; }
        public int Size { get; set; }
        public override string ToString()
        {
            return $"{Name} ({Type}) = {Price:C}";
        }
    }
