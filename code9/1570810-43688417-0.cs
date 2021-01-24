    public static class Globals
    {
        public static int UserId;
        public static string UserGroup;
    }
    public partial class App : Application
    {
        public App()
        {
            LoadUserPermissions();
        }
        public void LoadUserPermissions()
        {
            string username = Environment.UserDomainName;
            DBClass db = new DBClass();
            Globals.UserId = db.GetUserIdFromDatabase(username);
            Globals.UserGroup = db.GetUserGroupFromDatabase(username);
        }
    }
