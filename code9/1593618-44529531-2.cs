    public class SomeDtoProfile : Profile
    {
        public SomeDtoProfile()
        {
            CreateMap<SomeDto, JObject>()
                .ConvertUsing(JObject.FromObject);
        }
    }
    public class SomeDto    
    {
        public string Name { get; set; }
    }
