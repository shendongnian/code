    public class DestinationProfile : Profile
    {
        public DestinationProfile()
        {
            this.CreateMap<Intermediate, Dest>()
                .ForMember(destination => destination.ValueFromSourceA, 
                           opt => opt.MapFrom(src => src.SourceA.A))
                .ForMember(destination => destination.ValueFromSourceB, 
                           opt => opt.MapFrom(src => src.SourceB.B));
        }
    }
    public class IntermediateProfile : Profile
    {
        public IntermediateProfile()
        {
            this.CreateMap<Intermediate, Dest>()
                .ForMember(destination => destination.ValueFromSourceA, map => map.MapFrom(src => src.SourceA.A))
                .ForMember(destination => destination.ValueFromSourceB, map => map.MapFrom(src => src.SourceB.B));
        // ----- TODO: Create mapping for source classes.
        }
    }
