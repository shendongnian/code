    public class NameNode
    {
        public string tag1
        {
            get; set;
        }
    
        [XmlText]
        public string Value
        {
            get; set;
        }
    
    }
    public class ObjSer
    {
        [XmlElement("Name")]        
        public NameNode Name
        {
            get; set;
        }
    }
