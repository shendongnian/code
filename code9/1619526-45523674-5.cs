    public interface IPasswordChange
    {
        public void Execute(string username, string newPassword);
    }
    public class SqlPasswordChange : IPasswordChange
    {
        UserContext UserContext { get; }
        public SqlPasswordChange(UserContext userContext)
        {
            UserContext = userContext;
        }
        public void Execute(string username, string newPassword)
        {
            DoAudit();
            UserContext.Users.Single(user => user.Username == username).Password = newPassword;
            UserContext.SaveChanges();
        }
    }
