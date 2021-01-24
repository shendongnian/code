    public interface IUserRepository
    {
        public void ChangePassword(string username, string newPassword);
        //other user related methods
    }
    public class SqlUserRepository : IUserRepository
    {
        UserContext UserContext { get; }
        public SqlUserRepository(UserContext userContext)
        {
            UserContext = userContext;
        }
        public void ChangePassword(string username, string newPassword)
        {
            DoAudit();
            UserContext.Users.Single(user => user.Username == username).Password = newPassword;
            UserContext.SaveChanges();
        }
        //other user related methods
    }
