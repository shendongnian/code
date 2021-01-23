    public class MyClass : ICloneable
    {
        public Guid Id { get; set; }
        public object Clone()
        {
            return new MyClass { Id = Id };
        }
    }
