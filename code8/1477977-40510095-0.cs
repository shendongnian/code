    class Order
    {
        // properties describing the order
        // and the customer who placed the order...
        public virtual Customer Customer { get; set; }
    }
    class Customer
    {
        // properties describing the customer
        // and the customer's orders...
        public virtual ICollection<Order> Orders { get; set; }
    }
