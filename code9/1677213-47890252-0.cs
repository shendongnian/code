    public class FooProfile : Profile
    {
        public FooProfile()
        {
            CreateMap<decimal, decimal>().ConvertUsing(x=> Math.Round(x,2));
            CreateMap<Foo, Foo>();
        }
    }
    public class Foo
    {
        public decimal X { get; set; }
    }
