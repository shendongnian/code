    Mapper.Initialize(c =>
    {
        c.Mappers.Insert(0, new DestinationObjectContainerMapper());
        c.Mappers.Insert(0, new SourceObjectContainerMapper());
    });
    Mapper.AssertConfigurationIsValid();
    public class DestinationObjectContainerMapper : BlackBoxObjectMapper
    {
        bool InterfaceMatch(Type x) => x.IsGenericType && typeof(INC<>).IsAssignableFrom(x.GetGenericTypeDefinition());
        Type CType(Type cdt) => cdt.GetInterfaces().Concat(new[] { cdt }).Where(InterfaceMatch).Select(x => x.GenericTypeArguments[0]).FirstOrDefault();
        public override bool IsMatch(TypePair context) => CType(context.DestinationType) != null;
        public override object Map(object source, Type sourceType, object destination, Type destinationType, ResolutionContext context)
        {
            var dcType = CType(destinationType);
            // Create a container if destination is null
            if (destination == null)
                destination = Activator.CreateInstance(typeof(NC<>).MakeGenericType(dcType));
            // This may also fail because we need the source type
            var setter = typeof(INC<>).MakeGenericType(dcType).GetProperty("Value").GetSetMethod();
            var mappedSource = context.Mapper.Map(source, sourceType, dcType);
            // set the value
            setter.Invoke(destination, new[] { mappedSource });
            return destination;
        }
    }
    public class SourceObjectContainerMapper : BlackBoxObjectMapper
    {
        bool InterfaceMatch(Type x) => x.IsGenericType && typeof(INC<>).IsAssignableFrom(x.GetGenericTypeDefinition());
        Type CType(Type cdt) => cdt.GetInterfaces().Concat(new[] { cdt }).Where(InterfaceMatch).Select(x => x.GenericTypeArguments[0]).FirstOrDefault();
        public override bool IsMatch(TypePair context) => CType(context.SourceType) != null;
        public override object Map(object source, Type sourceType, object destination, Type destinationType, ResolutionContext context)
        {
            // this is only obtainable if destination is not null - so this will not work.
            var scType = CType(sourceType);
            // destination could also be null, this is another anavoidable throw
            object sourceContainedValue = null;
            if (source != null)
            {
                var getter = typeof(INC<>).MakeGenericType(scType).GetProperty("Value").GetGetMethod();
                sourceContainedValue = getter.Invoke(source, new Object[0]);
            }
            // map and return
            return context.Mapper.Map(sourceContainedValue, scType, destinationType);
        }
    }
