    public class Commission
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public double Rate { get; set; }
        public Party Party { get; set; } // <-- "parent" party link here
    }
    
    public class Agency : Party
    {
        public string AgencyCode { get; set; }
        [InverseProperty("Party")] // <-- link this collection with Party.Party
        public ICollection<Commission> Commissions { get; set; }
    }
    
    public class Carrier : Party
    {
        public string CarrierCode { get; set; }
        [InverseProperty("Party")] // <-- link this collection with Party.Party
        public ICollection<Commission> Commissions { get; set; }
    }
