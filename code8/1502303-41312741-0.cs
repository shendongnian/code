    public enum Db
    {
        Server_Name,
        DB_Name,
        DB_User,
        DB_Password,
    }
    public enum Default
    {
        Title,
        Keyword
    }
    public enum Status
    {
        Approved,
        Rejected,
        Suspened
    }
    public static class _const
    {
        public static Dictionary<Db, string> db = new Dictionary<Db, string>()
        {
            {Db.Server_Name, "ServerName"},
            {Db.DB_Name, "DBName"},
            {Db.DB_User, "UserName"},
            {Db.DB_Password, "Password"}
        };
        public static Dictionary<Default, string> defaults = new Dictionary<Default, string>()
        {
            {Default.Title, "DefaultTitle"},
            {Default.Keyword, "DefaultKeyWord"}
        };
        public static Dictionary<Status, string> status = new Dictionary<Status, string>()
        {
            {Status.Approved, "Approved"},
            {Status.Rejected, "Rejected"},
            {Status.Suspened, "Suspended"}
        };
    }
