    public class ServiceProvider 
    {
        [XmlElement("ID")]
        public SettingId SettingId { get; set; }
 
        [XmlElement]
        public string Username { get; set; }
        [XmlElement]
        public string URL { get; set; }
        [XmlElement]
        public string Password { get; set; }
    }
