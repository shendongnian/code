    public class TCReverse<X,Y> : ITypeConverter<IContainer<X>, Y>
    {
        public Y Convert(IContainer<X> source, Y destination, ResolutionContext context)
        {
            var use = source == null ? default(X) : source.Value;
            return context.Mapper.Map(use, destination);
        }
    }
    public class TCForward<X,Y> : ITypeConverter<X, IContainer<Y>>
    {
        public IContainer<Y> Convert(X source, IContainer<Y> destination, ResolutionContext context)
        {
            if (destination == null)
                destination = new Container<Y>();
            destination.Value = context.Mapper.Map(source, destination.Value);
            return destination;
        }
    }
