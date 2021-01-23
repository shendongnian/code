    public class UserRepository<T> where T : BaseUser
    {
      public UserRepository(IDataRepository dataRepository)
      {
      }
      
      // ... expose underlying dataRepository.Users here, while enforcing the T
    }
