    class Customer
    {
        [Key]
        public string Name { get; set; }
    }
    class Order
    {
        [Key]
        public int OrderNumber { get; set; }
        public decimal Total { get; set; }
    }
    
    class MyContext : DbContext
    {
        public MyContext()
        {
            //connect MyContext to some data source here
            Customers.Add(new Customer { Name = "John" });
            Customers.Add(new Customer { Name = "Jacob" });
            Customers.Add(new Customer { Name = "Hannah" });
        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        
        public IQueryable<TEntity> Buscar<TEntity>(Expression<Func<TEntity, bool>> predicate) 
            where TEntity : class
        {
            return this.Set<TEntity>().Where(predicate).AsQueryable<TEntity>();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            MyContext _context = new MyContext();
            IQueryable<Customer> _customers = _context.Buscar<Customer>(c=>c.Name.StartsWith("J"));
            foreach(Customer cust in _customers)
            {
                Console.WriteLine("Customer Name=" + cust.Name);
            }
            Console.ReadKey();
        }
    }
