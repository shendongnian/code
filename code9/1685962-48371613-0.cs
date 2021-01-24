    Mapper.Initialise(cfg =>
    {
        cfg.CreateMap(typeof(void), typeof(IContainer<>)).ConvertUsing(typeof(TCf<,>));
        cfg.CreateMap(typeof(IContainer<>), typeof(void)).ConvertUsing(typeof(TCb<,>));
    });
    class TCf<X, Y> : ITypeConverter<X, IContainer<Y>>
    {
        public IContainer<Y> Convert(X source, IContainer<Y> destination, ResolutionContext context)
        {
            if (destination == null)
                destination = new Container<Y>();
            destination.Value = context.Mapper.Map<Y>(source);
            return destination;
        }
    }
    class TCb<X, Y> : ITypeConverter<IContainer<X>, Y>
    {
        public Y Convert(IContainer<X> source, Y destination, ResolutionContext context)
        {
            var use = source == null ? default(X) : source.Value;
            return context.Mapper.Map<Y>(use);
        }
    }
