    public class MappingProfile : Profile
    {
      public MappingProfile()
      {
        CreateMap<Source.EMP, Target.EMPInfo>()
          .ForMember(dest => dest.id, opt => opt.MapFrom(src => src.empid))
          .ForMember(dest => dest.EmpName, opt => opt.MapFrom(src => src.Name));
        CreateMap<Source.EmpContact, Target.EmpContact>();
        CreateMap<Source.EMPDetails, Target.EMPPerdata>()
          .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.Name));
        CreateMap<Source.EmpAdd, Target.EmpAdressInfo>();
      }
    }
