    public class UserRepository : IUserRepository
    {
        public User async GetByIdAsync(int id)
        {
            using (var dbContext = new MyDbContext())
            {
                var data = await dbContext.FindAsync((UserData user) => user.Id == id);
                return new User(data);
            }
        }
    }
