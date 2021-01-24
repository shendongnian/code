    class Source
    {
        public string Foo { get; set; }
    }
    class Dest
    {
        public DateTime Bar { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Source, Dest>().ForMember(d => d.Bar, opt => opt.MapFrom(s => Convert.ToDateTime(s.Foo)));
            });
            var src = new Source { Foo = "01/01/2017" };
            var dst = Mapper.Map<Dest>(src);
            Console.WriteLine(dst.Bar);
        }
    }
