    public class TypeConverter
    {
        public TypeConverter(IEnumerable<OneWayTypeConverterBase> converters)
        {
            _converters = converters
                .GroupBy(x => x.AcceptsType)
                .ToDictionary(
                    kSource => kSource.Key,
                    vSource => vSource
                        .ToDictionary(kTarget => kTarget.ReturnsType, vTarget => vTarget));
        }
    
        private Dictionary<Type, Dictionary<Type, OneWayTypeConverterBase>> _converters;
    
        public TTarget ConvertType<TSource, TTarget>(TSource sourceObject)
        {
            Dictionary<Type, OneWayTypeConverterBase> baseConverters;
    
            if (_converters.TryGetValue(sourceObject.GetType(), out baseConverters))
            {
                OneWayTypeConverterBase baseConverter;
    
                if (baseConverters.TryGetValue(typeof(TTarget), out baseConverter))
                {
                    OneWayTypeConverter<TSource, TTarget> converter = baseConverter as OneWayTypeConverter<TSource, TTarget>;
    
                    if (converter != null)
                    {
                        return converter.Convert(sourceObject);
                    }
                }
    
                throw new InvalidOperationException("No converter found for that target type");
            }
            else
            {
                throw new InvalidOperationException("No converters found for that source type");
            }
        }
    }
