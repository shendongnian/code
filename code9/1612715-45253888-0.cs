    public interface IUserDataAccessor {
        IUserData UserData { get; }
    }
    public class UserDataAccessor : IUserDataAccessor {
        private readonly RegisteredUserData registeredUserData;
        private readonly NotLoggedInUserData notLoggedInUserData;
        
        public UserDataAccessor(
            RegisteredUserData registeredUserData,
            NotLoggedInUserData notLoggedInUserData) {
            this.registeredUserData = registeredUserData;
            this.notLoggedInUserData = notLoggedInUserData;
        }    
        
        public IUserData UserData {
            get {
                if (HttpContext.Current?.User?.Identity?.IsAuthenticated) {
                    return registeredUserData;
                }
                return notLoggedInUserData;
            }
        }
    }
