        class SourceA : ISource { 
            public string X { get; set; } 
        }
        class SourceB : ISource { 
            public string Y { get; set; } 
        }
        
        cfg.CreateMap<ISource, DestBase>
           .Include<SourceA, DestA>
           .Include<SourceB, DestB>
           .Include<SourceC, DestC>
           .ForMember(dest => dest.Z, , o => o.MapFrom(src => new List<string>()));
        cfg.CreateMap<SourceA, DestA>()
            .ForMember(dest => dest.X, o => o.MapFrom(src => src.X));
    
        cfg.CreateMap<SourceB, DestB>()
            .ForMember(dest => dest.Y, o => o.MapFrom(src => src.Y));
        // still need to create a map even if no additional properties are to be mapped
        cfg.CreateMap<SourceC, DestC>();
