    public interface Field
    {
        object Value { get; }
    }
    public interface Field<T> : Field
    {
        new T Value { get; }
    }
    public class MyField<T> : Field<T>
    {
        public T Value { get; } // generic
        object Field.Value => Value; // non generic
    }
