    [Serializable]
    public class Config
    {
        public ConfigLogin Login { get; set; }
    }
    [XmlRoot("Login")]
    public class ConfigLogin
    {
        public string Code { get; set; }
        public string Pass { get; set; }
    }
