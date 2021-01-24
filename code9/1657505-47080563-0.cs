    [DataContract(Name = "SendGridBounce")]
    public class SendGridBounce
    {
        [DataMember(Name ="created")]
        public int Created { get; set; }
        [DataMember(Name = "email")]
        public string Email { get; set; }
        [DataMember(Name = "reason")]
        public string Reason { get; set; }
        [DataMember(Name = "status")]
        public string Status { get; set; }
    }
