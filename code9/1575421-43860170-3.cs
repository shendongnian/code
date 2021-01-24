    class Manufacturer
    {
        public string Name;
        public string Address;
        public string City;
    }
    
    class Product
    {
        public Manufacturer[] Manufacturers;
    }
    
    class Order
    {
        public Product[] Products;
    }
    static void Main(string[] args)
    {
        var cities = new string[] { "a", "b" };
        Order[] orders = null;
        orders.SelectMany(o => o.Products.SelectMany(p => p.Manufacturers.Select(m => new { o, p, m })))
            .Where(g => cities.Contains(g.m.City))
            .ToList();
        }
