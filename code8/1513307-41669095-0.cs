    public class SQLitePlatformInstance : ISQLitePlatformInstance
    {
        public ISQLitePlatform GetSQLitePlatformInstance()
        {
            return new SQLitePlatformAndroid();
        }
    }
