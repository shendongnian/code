    public abstract class OneWayTypeConverterBase : IConvertFromType, IConvertToType
    {
        public abstract Type AcceptsType { get; }
        public abstract Type ReturnsType { get; }
    }
