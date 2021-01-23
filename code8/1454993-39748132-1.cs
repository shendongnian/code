    public class ApplicationUserResponseFactory
    {
        private MapperConfiguration _mapperConfiguration;
        public ApplicationUserResponseFactory(HttpRequestMessage httpRequestMessage) 
        {
            UrlHelper urlHelper = new UrlHelper(httpRequestMessage);
            _mapperConfiguration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ApplicationUser, ApplicationUserResponseModel>()
                    .ForMember(dest => dest.Url, opt => opt.MapFrom(src => UrlHelper.Link("GetUserById", new { id = src.Id })));
            });
            
        }
        public ApplicationUserResponseModel Create(ApplicationUser applicationUser)
        {
            return _mapperConfiguration.CreateMapper().Map<ApplicationUserResponseModel>(applicationUser);
        }
    }
