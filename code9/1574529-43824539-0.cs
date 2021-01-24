    [XmlRoot("feed", Namespace = "http://www.w3.org/2005/Atom")]
       
    
      public class Feed
      {
        
        //ADD A CONSTRUCTOR AND CREATE LIST
        public Feed()
        {
           Author1 = new Author();
           Entries = new List<Entry>();
    
        }
    
        [XmlElement("author")]
        public Author Author1 { get; set; }
    
        [XmlElement("entry")]
        public List<Entry> Entries { get; set; }
    
        [XmlElement("id")]
        public string Id { get; set; }
    }
