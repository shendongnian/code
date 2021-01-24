    public class StringList
    {
        [XmlElement(ElementName = "string")]
        public List<string> String { get; set; }
    }
    [XmlRoot(ElementName = "ElizaConversation")]
    public class ElizaConversation
    {
        [XmlElement(ElementName = "KeywordList")]
        public StringList KeywordList { get; set; }
        [XmlElement(ElementName = "ResponseList")]
        public StringList ResponseList { get; set; }
    }
