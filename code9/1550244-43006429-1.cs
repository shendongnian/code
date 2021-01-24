    public class UserService : IUserService
    {
       private readonly IRepository<User> _repository;
    
       public UserService(IRepository<User> repository)
       {
          _repository = repository;
       }
    
       public async Task<User> GetUserByUserNameAsync(string userName)
       {
          var query = _repository.Entities
             .Where(x => x.UserName == userName);
    
       return await query.FirstOrDefaultAsync();
    }
