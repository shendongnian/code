            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<IEnumerable<People>, PersonModel>()
                    .ForMember(
                        model => model.LocationDisplay, 
                        conf => conf.MapFrom(p => p.FirstOrDefault().City.Name))
                    .ForMember(
                        model => model.AverageVote,
                        conf => conf.MapFrom(p => p.FirstOrDefault().PersonVoes.Average(votes => votes.Vote)));
            });
