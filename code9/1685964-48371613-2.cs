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
                // if Y was object we could not create the correct container type
                destination = new Container<Y>(); 
            // if Y was object and source was null, we could not map to the correct type
            destination.Value = context.Mapper.Map<Y>(source);
            return destination;
        }
    }
    class TCb<X, Y> : ITypeConverter<IContainer<X>, Y>
    {
        public Y Convert(IContainer<X> source, Y destination, ResolutionContext context)
        {
            // if X was object and source was null, we could not choose an appropriate default
            var use = source == null ? default(X) : source.Value;
            // if Y was object and destination was null, we could not map to the correct type
            return context.Mapper.Map<Y>(use);
        }
    }
