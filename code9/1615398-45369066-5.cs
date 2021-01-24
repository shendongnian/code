    [XmlRoot("Envelope", Namespace="http://schemas.xmlsoap.org/soap/envelope/")]
    public class Envelope {
        [XmlElement("Body", Namespace="http://schemas.xmlsoap.org/soap/envelope/")]
        public Body Body { get; set; }
    }
    
    public class Body {
        [XmlElement("Login", Namespace="http://www.e-courier.com/software/schema/public/")]
        public Login Login { get; set; }
    }
    
    public class Login {
        [XmlAttribute("UserName")]
        public string UserName { get; set; }
        [XmlAttribute("Password")]
        public string Password { get; set; }
        [XmlAttribute("WebSite")]
        public string WebSite { get; set; }
    }
