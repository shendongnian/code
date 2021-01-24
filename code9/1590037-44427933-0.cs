    class Program
    {
        static void Main(string[] args)
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Source, DestinationMaster>().ForMember(dest => dest.Child, act => act.MapFrom(s => new DestinationChild { GrossAmount = s.GrossAmount}));
                cfg.CreateMap<DerivedSource, DerivedDestinationMaster>().IncludeBase<Source, DestinationMaster>().ForMember(dest => dest.Child, act => act.MapFrom(s => new DerivedDestinationChild { GrossAmount = s.GrossAmount }));
            });
            var source = new Source() {GrossAmount = 99};
            var destinationMaster = Mapper.Map<DestinationMaster>(source);
            Debug.Assert(destinationMaster.Child.GrossAmount == source.GrossAmount);
            Debug.Assert(destinationMaster.Child.GetType() == typeof(DestinationChild));
            var derivedSource = new DerivedSource() {GrossAmount = 10};
            var derivedDestinationMaster = Mapper.Map<DerivedDestinationMaster>(derivedSource);
            Debug.Assert(derivedDestinationMaster.Child.GrossAmount == derivedSource.GrossAmount);
            Debug.Assert(derivedDestinationMaster.Child.GetType() == typeof(DerivedDestinationChild));
        }
    }
