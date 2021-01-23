    [System.SerializableAttribute()]
    public partial class Req {
    
        [System.Xml.Serialization.XmlElementAttribute("book")]
        public catalogBook[] book { get; set; }
      }
    
   
    [System.SerializableAttribute()]
    public partial class catalogBook {
    
        public string author { get; set; }
    
        public string title { get; set; }
    
        public string genre { get; set; }
    
        public decimal price { get; set; }
    
        public System.DateTime publish_date { get; set; }
    
        public string description { get; set; }
    
        public string id { get; set; }
        
     }
