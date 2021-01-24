    public class IdentityCard
    {
        public DateTime? IdentityCardExpirationDate { get; set; }
    }
    public class Notes
    {
        //No idea what should be in here... 
    }
    public class BasicData
    {
        public string PersonType { get; set; }
        public bool AgreeWithCompleteAnalysis { get; set; }
        public bool InvestmentInterest { get; set; }
    }
    public class Agent
    {
        public string FullName { get; set; }
        public string MobileNumberPdf { get; set; }
        public string MobileNumber { get; set; }
        public IdentityCard IdentityCard { get; set; }
        public IdentityCard SecondIdentityCard { get; set; }
        public Notes Notes { get; set; }
        public string Sign { get; set; }
    }
    //Note: THIS is the actual class that matches the JSON sample given.
    public class ParentObject
    {
        public string insured_agent_flag { get; set; }
        public int Id { get; set; }
        public Agent Agent { get; set; }
        public BasicData BasicData { get; set; }
        public IEnumerable<string> NonOfferedProducts { get; set; }
    }
