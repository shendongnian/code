    using System.Collections.Generic;
    using System.Xml.Serialization;
    public class Story {
    
        [XmlAttribute("StoryId")]
        public int storyId;
    
        [XmlElement("Card")]
        public List<Card> cards = new List<Card>();
    }
