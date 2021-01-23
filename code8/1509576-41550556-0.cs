    public class RocketRequest
    {
        public string Id { get; set; }
        public int RocketRequestID { get; set; }
        public int LoanRocketID { get; set; }    
        public DateTime RequestDate { get; set; }    
        public int CreatedByID { get; set; }    
        public string RequestXML { get; set; }
    }
...
    var collection = db.GetCollection<RocketRequest>("RocketRequest");  
