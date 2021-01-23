    public class MyClass
    {
        public Guid Id { get; set; }
        public MyClass() { }
        public MyClass(MyClass other)
        {
            Id = other.Id;
        }
    }
