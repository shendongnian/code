    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            //Register all model with Dtos here
            CreateMap<UserMenuReadModel, UserMenuDto>();
        }        
    }
