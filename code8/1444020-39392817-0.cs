    public struct TryResult<T>
    {
        internal readonly T Value;
        internal readonly Exception Exception;
        public TryResult(T value)
        {
            Value = value;
            Exception = null;
        }
        public TryResult(Exception e)
        {
            Exception = e;
            Value = default(T);
        }
        public static implicit operator TryResult<T>(T value) =>
            new TryResult<T>(value);
        internal bool IsFaulted => Exception != null;
        public override string ToString() =>
            IsFaulted
                ? Exception.ToString()
                : Value.ToString();
        public static readonly TryResult<T> Bottom = new InvalidOperationException();
    }
