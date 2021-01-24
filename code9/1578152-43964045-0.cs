        public class UserIDGenerator : IUserIDGenerator
        {
            private int nextUserID = 100;
    
            public int getNextUserID()
            {
                return nextUserID++;
            }
        }
     
    	public class UserAdministration : IUserAdministration
        {
            private List<User> users = new List<User>();
    
            private IUserIDGenerator userIDGenerator;
    
            public UserAdministration(IUserIDGenerator userIDGenerator)
            {
                this.userIDGenerator = userIDGenerator;
            }
    
            public bool addUser(String firstName, String lastName, String email, String password)
            {
                users.Add(new User(userIDGenerator.getNextUserID(), firstName, lastName, email, password));
                return true;
            }
        }
