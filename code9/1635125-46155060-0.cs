    public interface CustomerRegistered
    {
        string FullName { get; }
    }
    
    public interface OrderPlaced
    {
        string Reference { get; }
        List<OrderLine> Lines { get; }
    }
    
    public class NewCustomerOrderedStuff : CustomerRegistered, OrderPlaced
    {
    ...
    }
    
    public class CustomerRegisteredConsumer : IConsumer<CustomerRegistered>
    
    public class OrderPlacedConsumer : IConsumer<OrderPlaced>
