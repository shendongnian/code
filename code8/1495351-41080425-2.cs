    class RefVal<T>
    {
        public T Value { get; set; }
        public RefVal(T value)
        {
            Value = value;
        }
        public override string ToString()
        {
            return Value.ToString();
        }
    }
