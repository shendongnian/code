    public class UserService : IUserService
    {
       private readonly IRepository<User> _repository;
    
       public UserService(IRepository<User> repository)
       {
          _repository = repository;
       }
    
       public async Task<IPagedList<User>> GetUsersAsync(UserPagedDataRequest request)
       {
       ...
       }
    }
