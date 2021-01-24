    public class APPMYPETS
    {
        public string note { get; set; }
        public string esito { get; set; }
    }
    
    public class CANINA
    {
        public string note { get; set; }
        public string esito { get; set; }
    }
    
    public class RootObject
    {
        public APPMYPETS APPMYPETS { get; set; }
        public CANINA CANINA { get; set; }
    }
