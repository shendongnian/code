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
        public static string SerializeXml<T>(T value)
        {
            var settings = new XmlWriterSettings();
            settings.OmitXmlDeclaration = true;
            var namespaces = new XmlSerializerNamespaces();
            namespaces.Add("q1", "http://tempuri.org/Logon");
            var xmlserializer = new XmlSerializer(typeof(T));
            var stringWriter = new StringWriter();
            using (var writer = XmlWriter.Create(stringWriter, settings))
            {
                xmlserializer.Serialize(writer, value, namespaces);
                return stringWriter.ToString();
            }
        }
        public static void Main(string[] args)
        {
            var login = new Login();
            login.ContactType = "XMLType";
            login.Email = "x@x.com";
            var a = SerializeXml(login);
            Console.WriteLine(a);
            Console.ReadLine();
        }
