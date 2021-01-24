    public class UserRepository : BaseRepository<User>
    {
        public UserRepository(MyDbContext context) : base(context)
        {
        }
    }
