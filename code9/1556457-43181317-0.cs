    public class Git
    {
        public string Login { get; set; }
        public string Password { get; set; }
    }
    public class ConfigEntry
    {
        public string Name { get; set; }
        public string ProjectURL { get; set; }
        public string AccountIdentifier { get; set; }
        public Dictionary<string,Git> Repositories { get; set; }
    }
