    public class UserRepository : IUserRepository
    {
        Repository<User> genericRepo;
        public UserRepository(Repository<User> genericRepo)
        {
            this.genericRepo = genericRepo;
        }
        public User GetUser(int userId)
        {
            return genericRepo.getById(userId);
        }
        // ...
     }
