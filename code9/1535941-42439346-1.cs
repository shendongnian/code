    string name = YourXmlNodes;
    
    XmlSerializer serializer = new XmlSerializer(typeof(AdditionalInfo));
    MemoryStream memStream = new MemoryStream(Encoding.UTF8.GetBytes(name));
    AdditionalInfo resultingMessage (AdditionalInfo)serializer.Deserialize(memStream);
    
    namespace ConsoleApplication1
    {
        [XmlRoot(ElementName = "AdditionalInfo")]
        public class AdditionalInfo
        {
            [XmlElement(ElementName = "Number")]
            public string Number { get; set; }
        }
    }
