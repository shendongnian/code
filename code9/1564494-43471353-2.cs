    public class GeneralMappingConfigProfile : Profile
    { 
        public GeneralMappingConfigProfile()
        {
            CreateMap<sourceObject, destinationObject>()
                    .ForMember(d => d.X, o => o.MapFrom(s => s.Y))
        }
    }
