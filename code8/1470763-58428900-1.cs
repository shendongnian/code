    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Iic, IicVM>()
                .ForMember(dest => dest.DepartmentName, o => o.MapFrom(src => src.Department.Name))
                .ForMember(dest => dest.PortfolioTypeName, o => o.MapFrom(src => src.PortfolioType.Name));
                //.ReverseMap();
        }
    }
