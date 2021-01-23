        public static void Main(string[] args)
        {
            DeserializeXml(@"C:\sample.xml");
        }
        public static void DeserializeXml(string xmlPath)
        {
            try
            {
                var xmlSerializer = new XmlSerializer(typeof(ConfigData));
                using (var xmlFile = new FileStream(xmlPath, FileMode.Open))
                {
                    var configDataOSinglebject = (ConfigData)xmlSerializer.Deserialize(xmlFile);
                    xmlFile.Close();
                }
            }
            catch (Exception e)
            {
                throw new ArgumentException("Something went wrong while interpreting the xml file: " + e.Message);
            }
        }
        [XmlRoot("ConfigData")]
        public class ConfigData
        {
            [XmlElement("Common")]
            public Common Common { get; set; }
            [XmlElement("SampleProduct")]
            public SampleProduct XSampleProduct { get; set; }
        }
        public class Common
        {
            [XmlElement("price")]
            public string Price { get; set; }
            [XmlElement("color")]
            public string Color { get; set; }
        }
        public class SampleProduct
        {
            [XmlElement("sample1")]
            public string Sample1 { get; set; }
            [XmlElement("sample2")]
            public string Sample2 { get; set; }
            [XmlElement("sample3")]
            public string Sample3 { get; set; }
        }
