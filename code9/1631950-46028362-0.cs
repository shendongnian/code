    public class Person
    {
        public int PersonId { get; set; }
        public string Name { get; set; }
        // ...
        public PersonType Type { get; set; }
    }
    public enum PersonType
    {
        Sales,
        CustomerService
    }
