    public abstract class Fuel
    {
        string Name { get; private set; }
        decimal Price { get; private set; }
        protected Fuel(string name, decimal price)
        {
            this.Name = name;
            this.Price = price;
        }
    }
