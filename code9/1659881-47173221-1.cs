    public partial class InternationalArrival
    {
        public decimal InternationalArrivalId { get; set; }
        public string AgentName { get; set; }
        
        public string AgentNameNew { get; set; }
        [Required]
        public string AgentCode { get; set; }
    
        
        public Nullable<DateTime> ArrivalDate { get; set; }
    
        [Required]
        public Nullable<int> ForPAX { get; set; }
        [Required]
        public Nullable<int> IndPAX { get; set; }
    }
