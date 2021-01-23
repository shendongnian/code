public class SourceToDestinationChildResolver : IValueResolver<Source, Destination, List<Child>>
{
    public List<Child> Resolve(Source source, Destination destination, List<Child> member, ResolutionContext context)
    {
        destination = destination ?? new Destination();
        destination.Children = destination.Children ?? new List<Child>();
        destination.Children.Add(new Child() { Property1 = source.Child1Property1, Property2 = source.Child1Property2 });
        destination.Children.Add(new Child() { Property1 = source.Child2Property1, Property2 = source.Child2Property2 });
        // This is not needed then
        // destination.Name = source.Name;
        return destination.Children;
    }
}
Configuration to use resolver:
public static class AutoMapperConfiguration
{
    public static MapperConfiguration Configure()
    {
        var config = new MapperConfiguration(
            cfg =>
            {
                cfg.CreateMap<Source, Destination>()
                   .ForMember(dest => dest.Children, opt => opt.MapFrom<SourceToDestinationChildResolver>())
            });
        return config;
    }
}
One thing that could help clarify my solution for myself is how is `List<Child> member` exactly used. Was not clear for me in the documentation, so someone please comment :)
  [1]: https://automapper.readthedocs.io/en/latest/Custom-value-resolvers.html
