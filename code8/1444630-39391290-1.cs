    public struct NullableLongWrapper
    {
        private readonly long? _value;
        public NullableLongWrapper(long? value)
        {
            _value = value;
        }
        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }
        public long? Value => _value;
    }
