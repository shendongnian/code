    public Profile()
    {
                CreateMap<ModelB, ViewModelB>()
                    .PreserveReferences().ConstructUsing((a, context) => new ViewModelB(context.Mapper))
                    .ForMember(c => c.Parent, opt => opt.MapFrom(s => s.Parent))
                    c.Players));
    }
