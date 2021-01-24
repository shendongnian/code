    public class Person
    {
        public Guid Id { get; set; }
    
        public static Person Create()
        {
            return new Person { Id = Guid.NewGuid() };
        }
    }
