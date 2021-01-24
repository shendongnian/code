    public struct NotNullable<T> where T : class
    {
        public NotNullable(T value)
        {
            Value = value ?? throw new ArgumentNulLException(nameof(value));
        }
    
        public T Value { get; }
    }
