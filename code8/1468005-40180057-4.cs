    public class Field
    {
        public string Name { get; set; }
    }
    public class Field<T> : Field
    {
        public T Value { get; set; }
    }
