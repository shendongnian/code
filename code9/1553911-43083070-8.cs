    [XmlRoot(ElementName = "ElizaConversation")]
    public class ElizaConversation
    {
        [XmlArray(ElementName = "KeywordList")]
        [XmlArrayItem(ElementName = "string")]
        public List<string> KeywordList { get; set; }
        [XmlArray(ElementName = "ResponseList")]
        [XmlArrayItem(ElementName = "string")]
        public List<string> ResponseList { get; set; }
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
