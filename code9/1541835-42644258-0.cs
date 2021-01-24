    public class Claim
    {
        public int TransportMode { get; set; }
        public string Date { get; set; }
        public string FromLocation { get; set; }
        public string ToLocation { get; set; }
        public double Ticket { get; set; }
        public double Conveyance { get; set; }
        public double Lodge { get; set; }
        public int Meals { get; set; }
    }
    
    public class Visitobj
    {
        public string Remarks { get; set; }
        public int UserID { get; set; }
        public string FindingsAtSite { get; set; }
        public string CheckInDate { get; set; }
        public string CheckOutDate { get; set; }
        public int VisitStatusID { get; set; }
        public int CreatedBy { get; set; }
        public string CreatedDateTime { get; set; }
        public Claim Claim { get; set; }
    }
    
    public class RootObject
    {
        public List<Visitobj> visitobj { get; set; }
    }
