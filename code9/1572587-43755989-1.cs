    public class Ingredient
    {
        public string Name { get; set; }
        public double Quantity { get; set; }
        public override string ToString()
        {
            return $"{Name}: {Quantity}";
        }
    }
