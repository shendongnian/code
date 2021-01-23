    public class DomainProfile1 : Profile
    {
      public DomainProfile1()
      {
        this.CreateMap<DomainType1, IDto>().ConstructUsing(f => new Dto1()).As<Dto1>();
        this.CreateMap<DomainType1, Dto1>().ForMember(m => m.P1, a => a.MapFrom(x => x.Prop1))
          .IncludeBase<IDomainType, IDto>().ReverseMap();
        this.CreateMap<Dto1, IDomainType>().ConstructUsing(dto => new DomainType1()).As<DomainType1>();
      }
    }
