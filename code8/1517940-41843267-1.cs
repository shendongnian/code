    public struct myStruct
    {
        public int field1;
        public string field2;
        [XmlElement("field3")]
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never), DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public ValueWrapper<byte>[] Field3Xml { get { return field3.ToWrapperArray(); } set { field3 = value.FromWrapperArray(); } }
        [XmlIgnore]
        public byte[] field3;
    }
    public struct ValueWrapper<T> where T : IConvertible
    {
        [XmlText]
        public T Value { get; set; }
        public static implicit operator ValueWrapper<T>(T b)
        {
            return new ValueWrapper<T> { Value = b };
        }
        public static implicit operator T(ValueWrapper<T> wrapper)
        {
            return wrapper.Value;
        }
    }
    public static class ValueWrapperExtensions
    {
        public static ValueWrapper<T>[] ToWrapperArray<T>(this T[] values) where T : IConvertible
        {
            if (values == null)
                return null;
            return values.Select(b => (ValueWrapper<T>)b).ToArray();
        }
        public static T [] FromWrapperArray<T>(this ValueWrapper<T>[] values) where T : IConvertible
        {
            if (values == null)
                return null;
            return values.Select(v => v.Value).ToArray();
        }
    }
