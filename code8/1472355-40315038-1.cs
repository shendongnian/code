    struct NullableEx<T>
    {
        private bool _hasValue;
        private T _value;
        public NullableEx(T value)
        {
            _hasValue = true;
            _value = value;
        }
        public bool HasValue { get { return _hasValue; } }
        public T Value { get { return _value; } }
        // You can also e.g. add implicit operators to convert
        // between T and NullableEx<T>, to implement equality
        // and hash code operations, etc.
    }
