    public struct Price : IComparer<Price>, IEquatable<Price>, ISerializable
    {
        private readonly decimal _value;
        public Price(Price value)
        {
            _value = value._value;
        }
        public Price(decimal value)
        {
            _value = value;
        }
        public int Compare(Price x, Price y)
        {
            return x._value.CompareTo(y._value);
        }
        public int Compare(Price x, decimal y)
        {
            return x._value.CompareTo(y);
        }
        public int Compare(decimal x, Price y)
        {
            return x.CompareTo(y._value);
        }
        public bool Equals(Price other)
        {
            return _value.Equals(other._value);
        }
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
                return false;
            return obj is Price && Equals((Price)obj);
        }
        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Value", _value);
        }
        public static implicit operator decimal(Price p)
        {
            return p._value;
        }
        public static implicit operator Price(decimal d)
        {
            return new Price(d);
        }
    }
