    public class Source
    {
        public string Value1 { get; set; }
    
        public string Value2 { get; set; }
    }
    public class Destination
    {
        public string Value1 { get; set; }
        public string Value2 { get; set; }
    }
    public class ObjectResolver : IMemberValueResolver<Source, Destination, string, string>
    {
        public string Resolve(Source s, Destination d, string source, string dest, ResolutionContext context)
        {
            return (string)context.Items["domainUrl"] + source;
        }
    }
    public class Program
    {
        public void Main()
        {
             var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<Source, Destination>()
                        .ForMember(o => o.Value1, opt => opt.ResolveUsing<ObjectResolver, string>(m=>m.Value1));
                });
    
                var mapper = config.CreateMapper();
                Source sr = new Source();
                sr.Value1 = "SourceValue1";
                Destination de = new Destination();
                de.Value1 = "dstvalue1";
                mapper.Map(sr, de, opt => opt.Items["domainUrl"] = "http://test.com/");       
        }
    }
