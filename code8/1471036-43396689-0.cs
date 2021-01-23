    public class ConvertSourceToDestination : ITypeConverter<Source, Destination>
    {
        public Destination Convert(Source source, Destination destination, ResolutionContext context)
        {
            destination = destination ?? new Destination();
            destination.Children = destination.Children ?? new List<Child>();
            destination.Children.Add(new Child() { Property1 = source.Child1Property1, Property2 = source.Child1Property2 });
            destination.Children.Add(new Child() { Property1 = source.Child2Property1, Property2 = source.Child2Property2 });
            destination.Name = source.Name;
            return destination;
        }
    }
    public static class SourceExtension
    {
        public static IEnumerable<Child> Children(this Source source)
        {
            yield return new Child() { Property1 = source.Child1Property1, Property2 = source.Child1Property2 };
            yield return new Child() { Property1 = source.Child2Property1, Property2 = source.Child2Property2 };
        }
        public static MapperConfiguration CreateMapping()
        {
            var config = new MapperConfiguration(
                cfg =>
                {
                    cfg.CreateMap<Source, Destination>()
                    .ForMember(dest => dest.Children, opt => opt.MapFrom(src => src.Children()));
                });
            return config;
        }
        public static MapperConfiguration CreateMapping2()
        {
            var config = new MapperConfiguration(
                cfg =>
                {
                    cfg.CreateMap<Source, Destination>().ConvertUsing(new ConvertSourceToDestination());
                });
            return config;
        }
    }
