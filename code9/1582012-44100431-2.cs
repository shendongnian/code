    public class UserRepository : IUserRepository
    {
        BlogDbContext context;
        public UserRepository(BlogDbContext context)
        {
            this.context = context;
        }
        public User GetUser(int userId)
        {
            return _context.Users.FirstOrDefault(x => x.Id == userId);
        }
        // ...
     }
