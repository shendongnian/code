    public class Level
    {
        [XmlAttribute]
        public string ID {get; set;}
        public Selection Selection {get; set;}
    }
    
    public class Selection {
        [XmlAttribute]
        public string Name {get;set;}
        public Content Content {get;set;}
    }
    
    public class Content {
        [XmlText]
        public string Data {get;set;}
    }
