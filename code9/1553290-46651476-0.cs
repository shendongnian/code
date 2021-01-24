    public class IgnoringNullValuesTypeConverter<T> : ITypeConverter<T, T> where T : class
    {
        public T Convert(T source, T destination, ResolutionContext context)
        {
            return source ?? destination;
        }
    }
    cfg.CreateMap<IEnumerable, IEnumerable>().ConvertUsing(new IgnoringNullValuesTypeConverter<IEnumerable>());
