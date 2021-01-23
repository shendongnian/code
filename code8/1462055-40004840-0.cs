    [DataContract]
    public class Filter
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public FilterOperator Operator { get; set; }
        [IgnoreDataMember]
        public object Value { get; set; }
        [DataMember]
        TypedSurrogate TypedValue
        {
            get
            {
                return TypedSurrogate.CreateSurrogate(Value);
            }
            set
            {
                if (value is TypedSurrogate)
                    Value = ((TypedSurrogate)value).ObjectValue;
                else
                    Value = value;
            }
        }
    }
    [DataContract]
    // Include some well-known primitive types.  Other types can be included at higher levels
    [KnownType(typeof(TypedSurrogate<string>))]
    [KnownType(typeof(TypedSurrogate<bool>))]
    [KnownType(typeof(TypedSurrogate<byte>))]
    [KnownType(typeof(TypedSurrogate<sbyte>))]
    [KnownType(typeof(TypedSurrogate<char>))]
    [KnownType(typeof(TypedSurrogate<short>))]
    [KnownType(typeof(TypedSurrogate<ushort>))]
    [KnownType(typeof(TypedSurrogate<int>))]
    [KnownType(typeof(TypedSurrogate<long>))]
    [KnownType(typeof(TypedSurrogate<uint>))]
    [KnownType(typeof(TypedSurrogate<ulong>))]
    [KnownType(typeof(TypedSurrogate<float>))]
    [KnownType(typeof(TypedSurrogate<double>))]
    [KnownType(typeof(TypedSurrogate<decimal>))]
    [KnownType(typeof(TypedSurrogate<DateTime>))]
    [KnownType(typeof(TypedSurrogate<Uri>))]
    [KnownType(typeof(TypedSurrogate<Guid>))]
    [KnownType(typeof(TypedSurrogate<string[]>))]
    public abstract class TypedSurrogate
    {
        protected TypedSurrogate() { }
        [IgnoreDataMember]
        public abstract object ObjectValue { get; }
        public static TypedSurrogate CreateSurrogate<T>(T value)
        {
            if (value == null)
                return null;
            var type = value.GetType();
            if (type == typeof(T))
                return new TypedSurrogate<T>(value);
            // Return actual type of subclass
            return (TypedSurrogate)Activator.CreateInstance(typeof(TypedSurrogate<>).MakeGenericType(type), value);
        }
    }
    [DataContract]
    public class TypedSurrogate<T> : TypedSurrogate
    {
        public TypedSurrogate() : base() { }
        public TypedSurrogate(T value)
            : base()
        {
            this.Value = value;
        }
        public override object ObjectValue { get { return Value; } }
        [DataMember]
        public T Value { get; set; }
    }
