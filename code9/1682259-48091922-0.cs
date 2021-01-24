    class Program
    {
        static void Main(string[] args)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<Origin, Destination>().ForMember(e => e.list, opts => opts.MapFrom(s => s.array.ToList())));
            Mapper.AssertConfigurationIsValid();
            Origin o = new Origin {array = new[] {"one", "two", "three"}};
            Destination d = Mapper.Map<Destination>(o);
            Console.WriteLine(string.Join(", ", d.list));
        }
    }
