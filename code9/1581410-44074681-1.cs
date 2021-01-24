    public class OneWayTypeConverter<TSource, TTarget> : OneWayTypeConverterBase
    {
        public OneWayTypeConverter(Func<TSource, TTarget> conversionMethod)
        {
            _conversionMethod = conversionMethod;
        }
    
        public override Type AcceptsType => typeof(TSource);
        public override Type ReturnsType => typeof(TTarget);
    
        private readonly Func<TSource, TTarget> _conversionMethod;
    
        public TTarget Convert(TSource sourceObject)
        {
            return _conversionMethod(sourceObject);
        }
    }
