    public class DonneesLocale
        {
            private List<Donnee> donnee = new List<Donnee>();
    
            [XmlArray("DonneesLocale")]
            public List<Donnee> Donnee
            {
                get { return donnee; }
                set { donnee = value; }
            }
        }
    
        [XmlType("Donnee")]
        public class Donnee
        {
            [XmlElement("id")]
            public int id { get; set; }
    
            [XmlElement("libelle")]
            public string libelle { get; set; }
    
            [XmlElement("email_asso")]
            public string email_asso { get; set; }
    
            [XmlElement("login")]
            public string login { get; set; }
    
            [XmlElement("psw")]
            public string psw { get; set; }
    
            [XmlElement("site")]
            public string site { get; set; }
    
            [XmlElement("description")]
            public string description { get; set; }
    
            [XmlElement("data_1_lib")]
            public string data_1_lib { get; set; }
    
            [XmlElement("data_1_val")]
            public string data_1_val { get; set; }
    
            [XmlElement("data_2_lib")]
            public string data_2_lib { get; set; }
    
            [XmlElement("data_2_val")]
            public string data_2_val { get; set; }
        }
    
    DonneesLocale dnl = new DonneesLocale();
    
            private void Serialize(object sender, EventArgs e)
            {
                for (int i = 0; i < 10; i++)
                {
                    var temp = new Donnee() { id = i, libelle = "libelle " + i, email_asso = "email_asso " + i, login = "login " + i, psw = "psw " + i, site = "site " + i, description = "description " + i, data_1_lib = "data_1_lib " + i, data_1_val = "data_1_val " + i, data_2_lib = "data_2_lib " + i, data_2_val = "data_2_val " + i };
                    dnl.Donnee.Add(temp);
                }
    
                try
                {
                    // to Save columnorders to the file
                    var serializer = new XmlSerializer(typeof(DonneesLocale));
                    var ns = new XmlSerializerNamespaces();
                    ns.Add("", "");
    
    
                    using (TextWriter writer = new StreamWriter(@"Your XML Path"))
                    {
                        serializer.Serialize(writer, dnl, ns);
                    }
    
                }
                catch { }
            }
    
            private void Deserialize(object sender, EventArgs e)
            {
                try
                {
                    if (File.Exists(@"Your XML Path"))
                    {
    
                        var deserializer = new XmlSerializer(typeof(DonneesLocale));
                        using (TextReader reader = new StreamReader(@"Your XML Path"))
                        {
                            dnl = (DonneesLocale)deserializer.Deserialize(reader);
                        }
    
                    }
                }
                catch
                {
                }
            }
