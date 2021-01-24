    [Serializable]
    public class AppSettings
    {
        public List<UserApps> Applications { get; set; }
    }
    [Serializable]
    public class UserApps
    {
        public string Path { get; set; }
        public string Name { get; set; }
    }
