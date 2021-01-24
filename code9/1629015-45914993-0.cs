    public interface IUserAppService: IApplicationService
    {
    	void ActivateUser(int userId);
    }
    
     
----
     public class UserAppService : IUserAppService
        {
            private readonly IRepository<User, long> _userRepository;
    
            public UserEmailer(IRepository<User, long> userRepository)
            {
                _userRepository = userRepository;
            }
       
            public void ActivateUser(int userId)
            {
                var user = _userRepository.Get(userId);
                user.IsActive = true;
                _userRepository.Update(user);
            }
    }
