    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            //Same properties
            CreateMap<Source1, ReturnObject>();
    
            //Difference properties
            CreateMap<Source2, ReturnObject>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(f => f.ProductId))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(f => f.ProductName))
                .ForMember(dest => dest.Type, opt => opt.MapFrom(f => f.ProductType));
            CreateMap<Source3, ReturnObject>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(f => f.ItemId))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(f => f.ItemName))
                .ForMember(dest => dest.Type, opt => opt.MapFrom(f => f.ItemType));
        }
    }
