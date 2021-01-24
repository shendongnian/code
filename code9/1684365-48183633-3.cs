    public struct NotNullable<T> where T : class
    {
        public NotNullable(T value)
        {
            Value = value ?? throw new ArgumentNullException(nameof(value));
        }
    
        public T Value { get; }
    }
