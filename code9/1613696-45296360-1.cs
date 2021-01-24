    using AutoMapper;
    // reuse configurations by putting them into a profile
    public class MyMappingProfile : Profile {
    	public MyMappingProfile() {
    		CreateMap<ApplicationUser, UserDto>();
            CreateMap<Gig, GigDto>();
            CreateMap<Notification, NotificationDto>();
    	}
    }
    
    // initialize Mapper only once on application/service start!
    Mapper.Initialize(cfg => {
        cfg.AddProfile<MyMappingProfile>();
    });
