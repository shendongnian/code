    public class UtLogonResponse
    {
        public string SessionID { get; set; }
    }
    
    public class RootObject
    {
        public UtLogonResponse utLogon_response { get; set; }
    }
