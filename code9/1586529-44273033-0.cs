    public class Contact : RealmObject
    {
        [PrimaryKey]
        public Id {get;set;}
    
        public ContactName {get; set;}
    
        public int isSync { get; set; }     
        public long timestamp {get;set;}
    }
