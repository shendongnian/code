    namespace TypeTraits
    {
    struct Number<T, TOperations> : IComparable, IFormattable, IConvertible, IComparable<Number<T, TOperations>>, IEquatable<Number<T, TOperations>>, IComparable<T>, IEquatable<T>
        where T : IComparable, IFormattable, IConvertible, IComparable<T>, IEquatable<T>
        where TOperations : Operations<Number<T, TOperations>>, new()
    {
        static readonly Operations<Number<T, TOperations>> Operations = new TOperations();
        public T Value { get; }
        public Number(T value)
        {
            Value = value;
        }
        public static implicit operator Number<T, TOperations>(T source) => new Number<T, TOperations>(source);
        public static implicit operator T(Number<T, TOperations> source) => source.Value;
        public override bool Equals(object obj) => Value.Equals(obj);
        public override int GetHashCode() => Value.GetHashCode();
        public override string ToString() => Value.ToString();
        public bool Equals(T other) => Value.Equals(other);
        public bool Equals(Number<T, TOperations> other) => Equals(other.Value);
        public int CompareTo(object obj) => Value.CompareTo(obj);
        public int CompareTo(T other) => Value.CompareTo(other);
        public int CompareTo(Number<T, TOperations> other) => CompareTo(other.Value);
        public string ToString(string format, IFormatProvider formatProvider) => Value.ToString(format, formatProvider);
        public TypeCode GetTypeCode() => Value.GetTypeCode();
        public bool ToBoolean(IFormatProvider provider) => Value.ToBoolean(provider);
        public byte ToByte(IFormatProvider provider) => Value.ToByte(provider);
        public char ToChar(IFormatProvider provider) => Value.ToChar(provider);
        public DateTime ToDateTime(IFormatProvider provider) => Value.ToDateTime(provider);
        public decimal ToDecimal(IFormatProvider provider) => Value.ToDecimal(provider);
        public double ToDouble(IFormatProvider provider) => Value.ToDouble(provider);
        public short ToInt16(IFormatProvider provider) => Value.ToInt16(provider);
        public int ToInt32(IFormatProvider provider) => Value.ToInt32(provider);
        public long ToInt64(IFormatProvider provider) => Value.ToInt64(provider);
        public sbyte ToSByte(IFormatProvider provider) => Value.ToSByte(provider);
        public float ToSingle(IFormatProvider provider) => Value.ToSingle(provider);
        public string ToString(IFormatProvider provider) => Value.ToString(provider);
        public object ToType(Type conversionType, IFormatProvider provider) => Value.ToType(conversionType, provider);
        public ushort ToUInt16(IFormatProvider provider) => Value.ToUInt16(provider);
        public uint ToUInt32(IFormatProvider provider) => Value.ToUInt32(provider);
        public ulong ToUInt64(IFormatProvider provider) => Value.ToUInt64(provider);
        public static Number<T, TOperations> operator+(Number<T, TOperations> lhs, Number<T, TOperations> rhs) => Operations.Add(lhs, rhs);
    }
    }
