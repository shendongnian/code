     public class UserProfile : Profile, IProfile
        {
            public UserProfile()
            {
                CreateMap<User, UserModel>();
                CreateMap<UserModel, User>();
            }
        }
    
