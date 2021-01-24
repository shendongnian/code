    using AutoMapper;
    // reuse configurations by putting them into a profile
    public class MyMappingProfile : Profile {
    	public MyMappingProfile() {
    		Mapper.CreateMap<ApplicationUser, UserDto>();
            Mapper.CreateMap<Gig, GigDto>();
            Mapper.CreateMap<Notification, NotificationDto>();
    	}
    }
    
    // initialize Mapper only once on application/service start!
    Mapper.Initialize(cfg => {
        cfg.AddProfile<MyMappingProfile>();
    });
