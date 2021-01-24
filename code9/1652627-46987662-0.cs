    public class Person
    {
        public Person()
        {
            this.Id = Guid.NewGuid();
        }
        public Guid Id { get; set; }
    }
