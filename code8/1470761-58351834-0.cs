    public class MappingProfile : Profile
    {
      public MappingProfile()
      {
          CreateMap<Domain, DomainDto>();
      }
    }
