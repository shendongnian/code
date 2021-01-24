    class Prof : Profile
    {
    	public Prof()
    	{
    		CreateMap<ProfileEntity, ProfileDto>()
    			.ForMember(dst => dst.Users, opt => opt.MapFrom(src =>
    				src.Users.Select(u => new { User = u, Profile = src })));
    	}
    }
