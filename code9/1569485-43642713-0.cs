            Mapper.Initialize(cfg =>
                {
                    cfg.CreateMap<DAL.Post, IPost>()
                        .ForMember(d => d.User, m => m.MapFrom(s => s.User))
                        .ForMember(d => d.UserId, m => m.MapFrom(s => s.User.Id))
                        .ForMember(d => d.Comments, m => m.MapFrom(s => s.Comments))
                    ;
                    cfg.CreateMap<IUser, DAL.User>().ReverseMap();
                    cfg.CreateMap<IComment, DAL.Comment>().ReverseMap();
                } 
            );
            Mapper.AssertConfigurationIsValid();
