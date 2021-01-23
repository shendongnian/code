    public class ValueEventArgs<T> : EventArgs
    {
        ValueEventArgs(T value)
        {
            Value = value;
        }
        public T Value { get; protected set; }
    }
