    [XmlRoot("apiXML")]
    public class Api
    {
         [XmlArray("recordList")]
         [XmlArrayItem("record", typeof(Record))]
         public List<Record> RecordList {get;set;}
    }
    
    [Serializable]
    public class Record
    {
        [XmlAttribute("id")]
        public int RecordId {get;set;}
        
        [XmlElement("id")]
        public int Id {get;set;}
        
        [XmlElement("administration_name")]
        public string AdministrationName {get;set;}
        
        [XmlElement("object_number")]
        public string ObjectNumber {get;set;}
        
        [XmlElement("creator")]
        public List<Creator> Creators {get;set;}
        
        [XmlElement("object_category")]
        public List<ObjectCategory> ObjectCategories {get;set;}
        
        [XmlElement("reproduction.reference")]
        public List<ReproductionReference> ReproductionReferences {get;set;}
        
        [XmlElement("title")]
        public List<Title> Titles {get;set;}
    }
    
    [Serializable]
    public class Title:Child
    {
        [XmlAttribute("invariant")]
        public bool Invariant {get;set;}
        
        [XmlAttribute("lang")]
        public string Culture {get;set;}
        
        [XmlText]
        public string Text {get;set;}
    }
    
    public class Child
    {
        [XmlIgnore]
        public int ParentId {get;set;}
    }
    
    [Serializable]
    public class Creator:Child
    {
        [XmlText]
        public string Text {get;set;}
    }
    
    [Serializable]
    public class ObjectCategory:Child
    {
        [XmlText]
        public string Text {get;set;}
    }
    
    [Serializable]
    public class ReproductionReference:Child
    {
        [XmlText]
        public string Text {get;set;}
    }
