    public struct DatabaseAccessData
    {
        public string DataSource { get; set; }
        public string DatabaseName { get; set; }
        public string DatabaseUserName { get; set; }
        public string DatabasePassword { get; set; }
    }
    public static class CommonConfigSettings
    {        
        private static string DataSource { get; set; }
        private static string DatabaseName { get; set; }
        private static string DatabaseUserName { get; set; }
        private static string DatabasePassword { get; set; }
        public static void SetDatabaseAccessData(DatabaseAccessData data)
        {
            DataSource = data.DataSource;
            DatabaseName = data.DatabaseName;
            DatabaseUserName = data.DatabaseUserName;
            DatabasePassword = data.DatabasePassword;
        }
        public static DatabaseAccessData GetDatabaseAccessData()
        {
            return new DatabaseAccessData
            {
                DataSource = DataSource,
                DatabaseName = DatabaseName,
                DatabaseUserName = DatabaseUserName,
                DatabasePassword = DatabasePassword
            };
        }
