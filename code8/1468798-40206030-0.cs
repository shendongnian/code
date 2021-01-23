    public interface IUserService
    {
      UserDto GetUser(int id);
    }
    public class UserService : IUserService
    { 
      IUserDataAccess userDataAccess;
      public UserService(IUserDataAccess userDataAccess)
      {
        this.userDataAccess=userDataAccess;
      }
      public UserDto GetUser(int id)
      {
         // with this.userDataAccess, get a User and map to UserDto
        // to do : return something
      }
    }
