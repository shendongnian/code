    public class StudentInformation
    {
        public object rollNumber { get; set; }
        public bool isClassLeader { get; set; }
        public string result { get; set; }
    }
    
    public class CollegeInformation
    {
        public List<string> allClass { get; set; }
        public string currencyAccepted { get; set; }
        public List<object> calendarDates { get; set; }
        public string currencyCode { get; set; }
        public object collegeCode { get; set; }
        public bool hasBulidingFundPrices { get; set; }
        public bool hasHostel { get; set; }
        public bool hasSecurityFares { get; set; }
    }
    
    public class Price
    {
        public int priceAmount { get; set; }
    }
    
    public class Place
    {
        public string destination { get; set; }
        public List<Price> price { get; set; }
    }
    
    public class Tripsdate
    {
        public string departureTripDate { get; set; }
        public List<Place> Places { get; set; }
    }
    
    public class Collegetrip
    {
        public List<Tripsdate> tripsdate { get; set; }
    }
    
    public class JsonResponse
    {
        public StudentInformation StudentInformation { get; set; }
        public CollegeInformation CollegeInformation { get; set; }
        public List<Collegetrip> Collegetrips { get; set; }
    }
