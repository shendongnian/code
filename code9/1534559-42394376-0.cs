    public class UserRepository : IUserRepository
    {
        private SchoolContext db;
    
        public UserRepository(SchoolContext db)
        {
            this.db = db;
        }
    
        public List<User> GetAll()
        {
            return db.User.ToList();
        }    
    }
