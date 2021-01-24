    public interface IUserRepository {
        Task<User> GetByNameAsync(string name);
        Task AddAsync(User user);
    }
    public interface IActiveDirectoryUserService {
        Task<AdUserAccount> GetByNameAsync(string name);
    }
    public class AdUserAccount {
        public  string Email { get; set; }
        public  string FirstName { get; set; }
        public  string LastName { get; set; }
    }
