    public struct DoubleContainer : IConvertible
    {
        private readonly double _value;
        private DoubleContainer(double value)
        {
            _value = value;
        }
        public static implicit operator double(DoubleContainer doubleContainer)
        {
            return doubleContainer._value;
        }
        public static DoubleContainer Create(double value)
        {
            return new DoubleContainer(value);
        }
        public double ToDouble(IFormatProvider provider) {
            return _value;
        }
        public bool ToBoolean(IFormatProvider provider) {
            // delegate to your double
            return ((IConvertible) _value).ToBoolean(provider);
        }
        // ... rest is skipped ...
