    class Program
    {
        static void Main(string[] args)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<A, ADto>();
                cfg.AddMemberConfiguration()
                    .AddName<ReplaceName>(_ => _.AddReplace(nameof(A.CreateDate), nameof(ADto.Created_dt)));
            });
            var mapper = config.CreateMapper();
            var a = new A { CreateDate = DateTime.UtcNow, X = "X" };
            var aDto = mapper.Map<ADto>(a);
        }
    }
    public class A
    {
        public DateTime CreateDate { get; set; }
        public string X { get; set; }
    }
    public class ADto
    {
        public DateTime Created_dt { get; set; }
        public string X { get; set; }
    }
