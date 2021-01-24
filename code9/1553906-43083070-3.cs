    [XmlRoot(ElementName = "KeywordList")]
    public class KeywordList
    {
        [XmlElement(ElementName = "string")]
        public List<string> String { get; set; }
    }
    [XmlRoot(ElementName = "ResponseList")]
    public class ResponseList
    {
        [XmlElement(ElementName = "string")]
        public List<string> String { get; set; }
    }
    [XmlRoot(ElementName = "ElizaConversation")]
    public class ElizaConversation
    {
        [XmlElement(ElementName = "KeywordList")]
        public KeywordList KeywordList { get; set; }
        [XmlElement(ElementName = "ResponseList")]
        public ResponseList ResponseList { get; set; }
    }
    [XmlRoot(ElementName = "ChatList")]
    public class ChatList
    {
        [XmlElement(ElementName = "ElizaConversation")]
        public List<ElizaConversation> ElizaConversation { get; set; }
    }
    [XmlRoot(ElementName = "ElizaResponses")]
    public class ElizaResponses
    {
        [XmlElement(ElementName = "ChatList")]
        public ChatList ChatList { get; set; }
    }
