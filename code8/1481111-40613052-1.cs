    [Serializable()]
        [XmlRoot(ElementName = "generalContent", Namespace = "uuid:bc85180b-db18-412f-b7ad-36a25ff4012f")]
        public class GeneralContent
        {
            [XmlElement(ElementName = "title")]
            public string Title { get; set; }
    
            [XmlElement(ElementName = "image")]
            public Image Image { get; set; }
    
            [XmlIgnore]
            public string Description { get; set; }
    
            [XmlElement(ElementName = "description")]
            public string EncryptedDescription
            {
               get { return Encrypt(Description); }
               set { Description = Decrypt(value); }
            }
        }
