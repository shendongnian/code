    cfg.CreateMap<StagingDto, Application>()
        .ForMember(dest => dest.Coverages,
            opt => opt.ResolveUsing(src => new ICoverage[]
            {
                new CoverageA
                {
                    Current = src.CoverageA.Current,
                    Code = src.Code
                },
                new CoverageB
                {
                    HasRecord = src.CoverageB.HasRecord,
                    Code = src.Code
                }
            }));
