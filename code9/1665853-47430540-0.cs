    class Program
    {
        static void Main(string[] args)
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<FooItem, BarItem>();
                cfg.CreateMap<Foo, Bar>()
                .ForMember(dest => dest.Objects, opt => opt.ResolveUsing<CustomResolver>());
            });
            Mapper.AssertConfigurationIsValid();
            var foo = new Foo()
            {
                Objects = new List<object>() { new FooItem() { Name = "name" } }
            };
            //var map = Mapper.Map<IEnumerable<FooItem>, List<BarItem>>(foo.Objects.Cast<FooItem>());
            var map = Mapper.Map<Foo, Bar>(foo);
        }
    }
    public class CustomResolver : IValueResolver<Foo, Bar, List<object>>
    { 
        public List<object> Resolve(Foo source, Bar destination, List<object> member, ResolutionContext context)
        {
            var map = Mapper.Map<IEnumerable<FooItem>, List<BarItem>>(source.Objects.Cast<FooItem>());
            return map.Cast<object>().ToList();
        }
    }
