    public class Customer
    {
        public int CustomerId; // identifies a customer
        public string Name; // the customer's name
        public ICollection<Order> Orders; // collection of customer's orders
    }
    public class Order
    {
        public int OrderId; // identifies an order
        public int CustomerId { get; } // ID of the customer who's order it is.
        public Customer Customer { get; } // The Customer entity of that customer
    }
