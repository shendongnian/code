    public class UserFactory : IUserFactory {
        private readonly IUserIdManager ids;
        public UserFactory(IUserIdManager ids) {
            this.ids = ids;
        }
        public User Create() { 
            var user = new User();
            user.UserId = ids.GetNextId();
            return user;
        }
        public User Create(String firstName, String lastName, String email, String password) { 
            var user = new User(firstName, lastName, email, password);
            user.UserId = ids.GetNextId();
            return user;
        }
    }
