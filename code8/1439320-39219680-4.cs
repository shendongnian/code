    public static class DBSetHelper
    {
        public static async Task<T> FindAsync<T>(
            this DbSet<T> set, 
            Expression<Func<T, bool>> match) 
            where T : BaseEntity
        {
            return await set.SingleOrDefaultAsync(match);
        }
    }
    . . .
    public class UserRepository : IUserRepository
    {
        public User async GetByIdAsync(int id)
        {
            using (var dbContext = new MyDbContext())
            {
                var data = await dbContext.Users.FindAsync(user => user.Id == id);
                return new User(data);
            }
        }
    }
