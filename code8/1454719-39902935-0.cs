    public class UserRepository
    {
        private MyDbContext _myDbContext;
        
        public UserRepository(MyDbContext myDbContext)
        {
            _myDbContext = myDbContext;
        }
    }
