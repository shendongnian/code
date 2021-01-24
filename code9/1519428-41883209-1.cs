    public class WLAuth
    {
        public string userid { get; set; }
        public string password { get; set; }
    } 
    public class SMSReturned
    {
        
        public WLAuth wlauth { get; set; }
        public string Ident { get; set; }
        public string identtype { get; set; }
        public string message { get; set; }
        public string userid { get; set; }
        public string password { get; set; }
    
    }
