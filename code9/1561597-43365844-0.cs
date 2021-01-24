            Mapper.Initialize(cfg => cfg.CreateMap<A, ABC>()
                .ForMember(dest => dest.AX, opt => opt.MapFrom(src => src.X))
                .ForMember(dest => dest.Aid, opt => opt.MapFrom(src => src.id))
                .ForMember(dest => dest.BY, opt => opt.MapFrom(src => src.b.Y))
                .ForMember(dest => dest.Bid, opt => opt.MapFrom(src => src.b.id))
                .ForMember(dest => dest.CZ, opt => opt.MapFrom(src => src.c.Z))
                .ForMember(dest => dest.Cid, opt => opt.MapFrom(src => src.c.id)));
            var a = new A
            {
                X = "I am A",
                id = 0,
                b = new B()
                {
                    Y = "I am B",
                    id = 1
                },
                c = new C()
                {
                    Z = "I am C",
                    id = 2
                }
            };
            var abc = Mapper.Map<A, ABC>(a);
