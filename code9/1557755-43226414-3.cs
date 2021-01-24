    Mapper.Initialize(cfg => {
        cfg.CreateMap<Source, Destination>()
            .ForMember(dest => dest.Total,
                opt => opt.ResolveUsing<CustomResolver, decimal>(src => src.SubTotal));
        
        cfg.CreateMap<OtherSource, OtherDest>()
            .ForMember(dest => dest.OtherTotal, opt => opt.ResolveUsing<CustomResolver, decimal>(src => src.OtherSubTotal));
    });
    public class CustomResolver : IMemberValueResolver<object, object, decimal, decimal> {
    
        public decimal Resolve(object source, object destination, decimal sourceMember, decimal destinationMember, ResolutionContext context) {
            // your mapper logic here
        }
    }
