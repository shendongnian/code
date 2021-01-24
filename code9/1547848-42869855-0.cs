    public interface IUsersService {
        GetAllUsersResponse GetAllUsers();
    }
    public class GetAllUsersResponse {
        public IList<User> usersDetails { get; set; }
        public string errorMessage { get; set; }
    }
