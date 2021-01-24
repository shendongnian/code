    public class MappingProfile : Profile
        {
            public MappingProfile()
            {
                CreateMap<QueryUniqueDto, QueryUnique>()
                    .ForMember(s=>s.UserClaim,opt=>opt.ResolveUsing<IdentityResolver>());
            }
        }
