    public abstract class Fuel
    {
        public string Name { get; private set; }
        public decimal Price { get; private set; }
        public override string ToString()
        {
            return string.Format(@"Name: {0} Price: {1}", Name, Price.ToString("C"));
        }
        protected Fuel(string name, decimal price)
        {
            this.Name = name;
            this.Price = price;
        }
    }
