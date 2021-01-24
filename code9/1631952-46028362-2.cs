    public class Person
    {
        public string Name { get; set; }
    }
    public class Sales : Person
    {
        public int SalesId { get; set; }
     
        // ...
    }
    public class CustomerService : Person
    {
        public int CustomerServiceId { get; set; }
        // ...
    }
