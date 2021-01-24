    public class Person
    {
        public int PersonId { get; set; }
        public string Name { get; set; }
        // ...
    }
    public class Sales
    {
        public int SalesId { get; set; }
        public int PersonId { get; set; }
        public virtual Person { get; set; }
        // ...
    }
    public class CustomerService
    {
        public int CustomerServiceId { get; set; }
        public int PersonId { get; set; }
        public virtual Person { get; set; }
        // ...
    }
