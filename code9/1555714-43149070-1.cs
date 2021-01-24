    using System.Collections.Generic;
    using System.Xml.Serialization;
    public class Deck {
    
        [XmlAttribute("DeckId")]
        public int deckId;
    
        [XmlElement("Card")]
        public List<Card> cards = new List<Card>();
    }
