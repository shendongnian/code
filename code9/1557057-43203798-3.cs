    static void Main(string[] args)
    {
        Mapper.Initialize(cfg => {
            cfg.CreateMap<Source, Destination>()
                .ForMember(dest => dest.D, opt => opt.ResolveUsing<CustomResolver>());
        });
        var source = new Source { A = 1, B = 2, C = 3 };
        var result = Mapper.Map<Source, Destination>(source);
    }
    public class Source
    {
        public int A { get; set; }
        public int B { get; set; }
        public int C { get; set; }
    }
    public class Destination
    {
        public int A { get; set; }
        public Dictionary<string, object> D { get; set; }
    }
