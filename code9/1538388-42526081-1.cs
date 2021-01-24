    public class PropertyVersionToValueConverter<TValue, TVersion> : ITypeConverter<PropertyVersion<TValue, TVersion>, TValue>
    {
        public TValue Convert(PropertyVersion<TValue, TVersion> source, TValue destination, ResolutionContext context)
        {
            if (source != null)
                return source.Value;
            return default(TValue);
        }
    }
    public class TrackedPropertyToPropertyVersionConverter<TValue, TVersion> : ITypeConverter<TrackedProperty<TValue, TVersion>, PropertyVersion<TValue, TVersion>>
    {
        public PropertyVersion<TValue, TVersion> Convert(TrackedProperty<TValue, TVersion> source, PropertyVersion<TValue, TVersion> destination, ResolutionContext context)
        {
            if (source != null && source.Count > 0)
                return source.Last();
            else return default(PropertyVersion<TValue, TVersion>);
        }
    }
    public class TrackedPropertyToValueConverter<TValue, TVersion> : ITypeConverter<TrackedProperty<TValue, TVersion>, TValue>
    {
        public TValue Convert(TrackedProperty<TValue, TVersion> source, TValue destination, ResolutionContext context)
        {
            var vers = context.Mapper.Map(source, typeof(TrackedProperty<TValue, TVersion>), typeof(PropertyVersion<TValue,TVersion>));
            return (TValue)context.Mapper.Map(vers, typeof(PropertyVersion<TValue, TVersion>), typeof(TValue));
        }
    }
