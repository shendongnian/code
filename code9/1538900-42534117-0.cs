    public class GetInfo 
    {
        public string IdNumber {get; set;}
        
        [MessageBodyMember(Namespace = "Some namespace"), XmlElement]
        public PersonData[] PersondataList {get; set;}
    }
