    [DataContract]
    public class Data{
        public RI RI {get; set;}
        public RU RU {get; set;}
    }
    
    [DataMember]
    public class RI{
        public int Node {get; set;}
        public int Subnode {get; set;}
    }
    
    [DataMember]
    public class RU{
        public int Node {get; set;}
        public int Subnode {get; set;}
    }
