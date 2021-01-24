    [Serializable]
    public class AppSettings
    {
        public List<UserApp> Applications { get; set; }
    }
    [Serializable]
    public class UserApp
    {
        public string Path { get; set; }
        public string Name { get; set; }
    }
