    public class PasswordChange
    {
        private DbSet<User> Users { get; set; }
        public PasswordChange(DbSet<User> users)
        {
            Users = users;
        }
        public void Execute(String username, String newPassword)
        {
            doAudit();
            Users.Single(user => user.Username == username).Password = newPassword;
        }
    }
    public class UserContext : DbContext
    {
        private DbSet<User> Users { get; set; }
        public changePassword(String username, String newPassword)
        {
            new PasswordChange(Users).Execute(username, newPassword);
            SaveChanges();
        }
    }
