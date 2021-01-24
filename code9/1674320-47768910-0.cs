        [XmlRoot("Login", Namespace = ""), Serializable()]
        public class Login { 
            [XmlElement("programCode")]
            public string ProgramCode { get; set; }
            [XmlElement("contactType")]
            public string ContactType { get; set; }
            [XmlElement("email")]
            public string Email { get; set; }
            [XmlElement("password")]
            public string Password { get; set; }
            [XmlElement("projectName")]
            public string ProjectName { get; set; }
        }
