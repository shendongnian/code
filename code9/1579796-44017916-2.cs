    public class Order
    {
        // primary Key
        public int Id {get; set;}
        // an Order has a collection of OrderLines:
        public virtual ICollection<OrderLine> OrderLines {get; set;}
        ...
    }
    public class OrderLine
    {
        public int Id {get; set;} // primary key
        // foreign key to owning Order
        public int OrderId {get; set;}
        public virtual Order Order {get; set;}
        public int OrderLineNo {get; set;}
        public int SequenceNo {get; set;}
        ...
    }
    public MyDbContrext : DbContext
    {
        public DbSet<Order> Orders {get; set;}
        public DbSet<OrderLine> OrderLines {get; set;}
        ...
    }
