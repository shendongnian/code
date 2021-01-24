    public class UserProfile: Profile
    {
        public UserProfile()
        {
           CreateMap<User, UserDto>(MemberList.None);
        }
    }
