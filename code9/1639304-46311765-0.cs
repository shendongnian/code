    class Customer
    {
        public Customer(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }
    
        public string FirstName { get; }
        public string LastName { get; }
    }
    class Vendor
    {
        public Vendor(string name, IEnumerable<Product> products)
        {
            Name = name;
            Products = new HashSet<Product>(products);
        }
        public bool IsStocked(Product product)
        {
            // determine if product is currently in stock...
        }
        public string Name { get; }
        public HashSet<Product> Products { get; }
    }
    
    class Product
    {
        // ... common product data.
    }
    
    class Order
    {
        public Order(
            DateTime createDate, Customer customer, 
            Vendor vendor, Product product, double quantity)
        {
            CreateDate = createDate;
            Customer = customer;
            Vendor = vendor;
            Product = product;
            Quantity = quantity;
        }
    
        public DateTime CreateDate { get; }
        public Customer Customer { get; }
        public Vendor Vendor { get; }
        public Product Product { get; }
        public double Quantity { get; }
    }
